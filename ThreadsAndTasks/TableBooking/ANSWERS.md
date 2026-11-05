# Assignment 02 — Answers

Student name: Mohamed Mostafa MOhamed Ahmed
Group / ID:

## What is wrong

there is a race Condition 40 customers want to book table at the same time
and ensure there is an left table at the same time where latest table is booked there is another thread booking at the same time as the result blew-->

- Customer-11 booked a table. Left=1
- Customer-24 booked a table. Left=-16
- Customer-01 booked a table. Left=-10
- Customer-02 booked a table. Left=-10
- Customer-03 booked a table. Left=-10
- Customer-04 booked a table. Left=-10
- Customer-05 booked a table. Left=-10
- Customer-06 booked a table. Left=2
- Customer-07 booked a table. Left=-4
- Customer-08 booked a table. Left=-15
- Customer-09 booked a table. Left=-16
- Customer-10 booked a table. Left=-10
- Customer-12 booked a table. Left=1
- Customer-13 booked a table. Left=0
- Customer-14 booked a table. Left=1
- Customer-15 booked a table. Left=1
- Customer-16 booked a table. Left=-1
- Customer-17 booked a table. Left=-4
- Customer-18 booked a table. Left=-4
- Customer-19 booked a table. Left=-15
- Customer-20 booked a table. Left=-17
- Customer-21 booked a table. Left=-18
- Customer-22 booked a table. Left=-15
- Customer-23 booked a table. Left=-17

* Booked=21, TablesLeft=-18

## How you fixed it

I will using lock to enforce threads to wait each other.
and this result

- Customer-01 booked a table. Left=4
- Customer-02 booked a table. Left=3
- Customer-03 booked a table. Left=2
- Customer-04 booked a table. Left=1
- Customer-05 booked a table. Left=0

* Booked=5, TablesLeft=0
