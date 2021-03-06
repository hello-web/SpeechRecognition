﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechRecognition.CNTK {
    public class DataContainer {
        private List<IDataSource> DataSources;

        public DataContainer(IEnumerable<IDataSource> dataSources) {
            DataSources = new List<IDataSource>(dataSources);
        }

        public ReadOnlyCollection<IDataSource> GetDataSources() {
            return DataSources.AsReadOnly();
        }

        public List<string> GetDataSourceNames() {
            return DataSources.Select(dataSource => dataSource.Name).ToList();
        }

        public IDataSource GetDataSource(string name) {
            return DataSources.First(dataSource => dataSource.Name == name);
        }

        /// <summary>
        /// Returns new DataContainer with current and added DataSources
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        public DataContainer AddDataSource(IDataSource dataSource) {
            DataContainer newContainer = new DataContainer(DataSources);
            newContainer.DataSources.Add(dataSource);
            return newContainer;
        }
    }
}
