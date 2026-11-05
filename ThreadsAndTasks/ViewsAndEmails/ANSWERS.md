# Assignment 05 — Answers

Student name: Mohamed Mostafa Mohamed Ahmed
Group / ID:

## Failures you observed

- System.InvalidOperationException because there are multiple threads add at the same index

## What you changed

- i have changed Dictionary to Concurrent Dictionary and using AddorUpdate() function because it is thread safe
- i have used Concurent Queue instead of Queue because it is thread safe

## Collection safety vs business-rule safety

- collections safety keep my collection safe from reace condition by using threa safe collections.
- Business-rule safe from inegrity and Accounting even used Collection is safe.
