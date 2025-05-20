using DataLayer;
using LogicLayer;

namespace PresentationLayer
{
    public static class ServiceLocator
    {
        private static ILogicService _logicService;

        public static ILogicService GetLogicService()
        {
            if (_logicService == null)
            {
                // Initialize the database first
                DatabaseInitializer.Initialize();
                
                // Create a new instance of Events_class that uses the database
                var events = new Events_class();
                _logicService = new LogicService(events);
            }
            return _logicService;
        }
    }
} 