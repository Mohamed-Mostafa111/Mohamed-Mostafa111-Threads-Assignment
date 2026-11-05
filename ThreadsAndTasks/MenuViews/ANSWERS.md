# Assignment 04 — Answers

Student name: Mohamed Mostafa Mohamed Ahmed
Group / ID:

## Why Expected and Actual disagree

- there is an Race Conditions Between threads at the same Increminter.
  if some threads accessed the same value increminter.
  - Expected: 400000
  - Actual: 206610

## What you changed

- i used Intrlocked() to make Lock at Spacific update process.

## When would you protect the update differently

--> when this variable inside Conditions so Intrlock not be usefull , we must use lock to lock If Condition Process
