#Application PostponeControllerTestWin
#Application PostponeControllerTestWeb

*Action New(Task)
  
*FillForm
 Description = Test Task One
 Due Date = 06/06/2011
 
*Action Save and New
  
*FillForm
 Description = Test Task Two
 Due Date = 07/07/2011
 
*Action Save and Close

*Action Navigation(Task)

*SelectRecords
 Columns = Description
 Row = Test Task One
 Row = Test Task Two
 
*Action Postpone

*CheckTable
 Columns = 'Due Date'
 Row = 6/7/2011
 Row = 7/8/2011
