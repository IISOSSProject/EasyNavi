using EasyNavi.PluginInterfaces.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.PluginInterfaces.Abstracts
{
    public class EasyNaviPluginBase : IEasyNaviPlugin
    {
        public Assembly AppAssembly { get; private set; }

        public Func<SQLiteConnection> DataBaseConnectionFactory { get; private set; }

        public IFileStragePath FileStragePath { get; private set; }


        public void RegistAppAssembly(Assembly assembly) => AppAssembly = assembly;

        public void RegistDataBaseConnectionFactory(Func<SQLiteConnection> factory) => DataBaseConnectionFactory = factory;

        public void RegistFileStragePath(IFileStragePath path) => FileStragePath = path;


        public virtual Task Init()=>Task.CompletedTask;


        public virtual void CreateDataBase(SQLiteConnection db) {; }

        public virtual Task<bool> DataUpdate() => Task.FromResult(true);
    }
}
