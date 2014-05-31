﻿using System;
using System.IO;
using System.Threading.Tasks;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Test.Mocks {
    public class StaticXmlRequester : IHttpRequester {

        public string Request<T>(Uri uri) {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null) {
                string baseDir = directoryInfo.FullName;
                string path = uri.PathAndQuery;
                string relPath =
                    path.Substring(path.Remove(path.LastIndexOf("/", StringComparison.Ordinal))
                        .LastIndexOf("/", StringComparison.Ordinal));
                relPath = relPath.Remove(relPath.LastIndexOf(".aspx", StringComparison.Ordinal)).Replace("/", "\\");
                relPath = baseDir + "\\Xml" + relPath;
                using (StreamReader reader = (File.OpenText(relPath))) {
                    return reader.ReadToEnd();
                }
            }
            throw new InvalidOperationException();
        }

        public Task<string> RequestAsync<T>(Uri uri) {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null) {
                string baseDir = directoryInfo.FullName;
                string path = uri.PathAndQuery;
                string relPath =
                    path.Substring(path.Remove(path.LastIndexOf("/", StringComparison.Ordinal))
                        .LastIndexOf("/", StringComparison.Ordinal));
                relPath = relPath.Remove(relPath.LastIndexOf(".aspx", StringComparison.Ordinal)).Replace("/", "\\");
                relPath = baseDir + "\\Xml" + relPath;
                using (StreamReader reader = (File.OpenText(relPath))) {
                    return reader.ReadToEndAsync();
                }
            }
            throw new InvalidOperationException();
        }
    }
}