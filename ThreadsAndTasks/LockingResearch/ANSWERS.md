# Assignment 03 — Answers

Student name: Mohamed Mostafa Mohamed Ahmed
Group / ID:

1. - used to make A lock at same shared Variable to prevent Race Conditions Error

2. - it is compiled to System.Threading.Monitor

3. - with lock:
     \- thread will wait up to inner thread to be finished
     \-it ensures only one thread executes a block of code at a time, but it has no built-in way for threads to talk to each other

- with Monitor we have more flixbility to control thread
  \- Monitor.TryEnter which lets you specefy a timeout . this prevent threads from getting stuck forevever in deadlocks.
  \- Monitor.Wait() and Monitor.Pulse() allowes thread to pasue or sleep and signal each other when spacific changes neede.

4. - Monitor.TryEnter() --> used when you want to make Lock with timeout..
   - Monitor.pulse() and Monitor.Wait() --> these two functions are used to coordenate more than one thread at the

5. lock (\_lockObj)
   {
   // Critical Section
   if (\_balance >= amount)
   {
   \_balance -= amount;
   }
   }

---

    try
    {
        Monitor.Enter(_lockObj, ref lockTaken);

        if (_balance >= amount)
        {
            _balance -= amount;
        }
    }
    finally
    {
        if (lockTaken)
        {
            Monitor.Exit(_lockObj);
        }
    }

Links:
https://dogukanuhn.medium.com/better-locking-with-system-threading-lock-421a378ed3fe
https://gemini.google.com/app/1a844bae35d0e0b7?is_sa=1&is_sa=1&android-min-version=301356232&ios-min-version=322.0&campaign_id=bkws&pt=9008&mt=8&ct=p-growth-sem-bkws

-
