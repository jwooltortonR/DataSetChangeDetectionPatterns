using System.Data;
using R.ChangeDataSetCapture.ChangeDetectionApproach;
using R.ChangeDataSetCapture.Interfaces;
using R.ChangeDataSetCapture.Interfaces.Enums;
using StructureMap;

namespace R.ChangeDataSetCapture
{
    public sealed class ChangeSetCapture
    {        
        public IConfiguration Configuration { get; set; }

        public ChangeSetCapture(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public void Process(DataSet dataSet)
        {            
            ////Load Persitance store from container
            var whatIHave = ObjectFactory.Container.WhatDoIHave();

            //var persistanceStoreCollectionName = "TestCollection";
         
            var keyColumnName = Configuration.KeyColumnName;
            var hashColumnsList = Configuration.HashColumnList;
            var persistenceStore = Configuration.PersistanceStore;
            var notifier = Configuration.Notifier;

            IChangeDetectionApproach retval = null;

            switch (Configuration.ChangeDetectionApproachType)
            {
                case ChangeDetectionApproachType.BruteForce:
                    retval = new BruteForceColumnHash(persistenceStore, notifier, keyColumnName, hashColumnsList);
                    break;
            }

            if (retval != null)
            {
            retval.Process(dataSet.Tables[0]);    
            }            
        }
   
    }
}
