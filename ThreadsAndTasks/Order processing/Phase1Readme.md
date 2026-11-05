# 1- Why are the sync and async times almost the same when orders are awaited one after another?

--> Because in both cases, execution happens sequentially one request after another

# 2-Is the thread ID before an await always the same as after it? Why? Use your own log lines as evidence.

-->Not necessarily. An `await` might resume execution on a different thread from the thread pool

# 3-What does the thread do while Task.Delay() is waiting? And while Thread.Sleep() is waiting?

-->Task.Delay(): Don't make blocking on the thread.
--> Thread.Sleep(): Block the thread

# 4-Why should a repository method return Task<T> instead of T?

--> To support asynchronous execution and to free main thread from blocking

# 5-What is the difference between File.ReadAllText and File.ReadAllTextAsync? Does the async

version occupy a thread while the disk is reading?
--> The File.ReadAllText is synchronous and block a thread, whereas the File.ReadAllTextAsync uses asynchronous I/O and does not block any thread while reading.
