﻿using ChatterBot.Core.Data;
using ChatterBot.Core.Interfaces;
using System.ComponentModel;

namespace ChatterBot.Core.SimpleCommands
{
    internal class SimpleCommandsPlugin : IPlugin
    {
        private readonly IDataStore _dataStore;
        private readonly ICommandsSet _commandsSet;

        public SimpleCommandsPlugin(IDataStore dataStore, ICommandsSet commandsSet)
        {
            _dataStore = dataStore;
            _commandsSet = commandsSet;
        }

        public void Initialize()
        {
            _commandsSet.Initialize(_dataStore.GetEntities<CustomCommand>());

            _commandsSet.CustomCommands.ListChanged += CustomCommandsOnListChanged;
        }

        private void CustomCommandsOnListChanged(object sender, ListChangedEventArgs e)
        {
            _dataStore.SaveEntities(_commandsSet.CustomCommands);
        }
    }
}