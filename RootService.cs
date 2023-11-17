using System.Diagnostics;

public class RootService {
    public async void MainFunction() {
        LinqPractice linqPractice = new LinqPractice();
        linqPractice.Comparing();
        // linqPractice.UsingLeftOutterJoin();

        // MyDIService myDIService = new MyDIService();
        // myDIService.RunExampleAboutDILifetimes();

        // ArrayVsList arrayVsList = new ArrayVsList();
        // arrayVsList.Knowledge();
        // Console.WriteLine($"MainFunction's ProcessId is: {Environment.ProcessId}");
        // Console.WriteLine($"MainFunction's CurrentManagedThreadId is: {Environment.CurrentManagedThreadId}");
        // AsychronousProgramming asychronousProgramming = new AsychronousProgramming();
        // // await asychronousProgramming.UsingCPUBound();
        // asychronousProgramming.UsingParallel();
        // Console.WriteLine($"MainFunction's CurrentManagedThreadId(2) is: {Environment.CurrentManagedThreadId}");
        // // AsychronousProgramming asychronousProgramming2 = new AsychronousProgramming();
        // // await asychronousProgramming2.UsingCPUBound();
        
        // Console.WriteLine("RootService.MainFunction has been completed");
        // var currentProcess = Process.GetCurrentProcess();
        // var threads = currentProcess.Threads;
        // foreach(var thr in threads) {
        //     Console.WriteLine($"{((ProcessThread)thr).Id}");
        // }
    }
}