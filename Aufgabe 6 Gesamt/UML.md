```mermaid
classDiagram
    class MyDate {
        -int[] monthLengths$
        +int Day
        +int Month
        +int Year
        +MyDate(day: int, month: int, year: int)
        +MyDate(day: int, year: int)
        +GetMonthLength(month: int, year: int) int$
        +IsLeapYear(year: int) bool$
        +Equals(date: MyDate) bool
        +IsSameDay(date: MyDate) bool
        +ToString() string
        +Tomorrow() MyDate
        +Yesterday() MyDate
```
