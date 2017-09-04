namespace BSILabs.Core.Forms.Snippets
{
    public class BusyHelper : IDisposable
    {
        private readonly ViewModelBase _context;
 
        public BusyHelper(ViewModelBase context)
        {
            _context = context;
            _context.IsBusy = true;
        }
 
        public void Dispose()
        {
            _context.IsBusy = false;
        }
    }

    public class MyViewModel : ViewModelBase
    {
        public async Task MyMethod()
        {
            using (new BusyHelper(this))
            {
                await MyLongRunningMethod();
            }
        }
    }
}