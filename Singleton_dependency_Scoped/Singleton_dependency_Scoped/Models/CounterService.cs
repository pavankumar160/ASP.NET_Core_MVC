namespace Singleton_dependency_Scoped.Models
{
    public interface ICounterService
    {
        int GetCount();
        void Increment();
    }

    //public class CounterService : ICounterService
    //{
    //    private int _count = 0;

    //    public int GetCount() => _count;

    //    public void Increment()
    //    {
    //        _count++;
    //    }
    //}

    public interface IUserService
    {
        string GetUser();
    }

    public class UserService : IUserService
    {
        private readonly string _user;

        public UserService()
        {
            // Simulate a new user per request
            _user = $"User-{Guid.NewGuid().ToString().Substring(0, 4)}";
        }

        public string GetUser() => _user;
    }


    public class CounterService : ICounterService
    {
        private int _count = 0;
        private readonly IUserService _userService; // <-- Scoped dependency

        public CounterService(IUserService userService)
        {
            _userService = userService;
        }

        public int GetCount() => _count;

        public void Increment()
        {
            _count++;
            Console.WriteLine($"Count = {_count}, User = {_userService.GetUser()}");
        }
    }



}

