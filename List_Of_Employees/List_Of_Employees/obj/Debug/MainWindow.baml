   M S B A M L   `   `   `  ����L  HList_Of_Employees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:List_Of_EmployeesList_Of_Employees  5   	   "    List_Of_Employees.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:List_Of_Employees     5   	   -   5          � Title$  Сотрудники��5   
   $	��800��64    � 
ResizeMode$ NoResize=�6@   .��5	      � $
��Left=�6   $	��790��6&   .+�5
   
   �� -   5         ��Name$ DeleteEmployee��5
      $��10(�6)   $	��➖��67   
����������#EA1313$��20��6�   $��20��6�   $��351,60,419,426q�6�   �� 5   
   -   5        $ AddEmployee��5      $��10(�6&   $	��➕��64   
����������#00AB44$��20��6|   $��20��6�   $��351,10,419,476q�6�   �� 5   
   -   5        $ UpdateEmployee��5      $��10(�6@   $
��📝��6N   
����������#FFCF40$��20��6�   $��20��6�   $��351,35,419,451q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ employeeDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��10,10,444,10q�5      $��Center=�5         
IsReadOnly . $	��336��6<   ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5   N   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Id+6l     5      -   5        LastNameColumn��$ Фамилия��5   Z   $
 * 6k    6=   �� *
LastName+6k     5      -   5        FirstNameColumn��$ Имя��5   \   $
 * 6i    6>   �� *	FirstName+6i     5      -	   5        DepartmentIdColumn��$! Id Департамента��5   b   $
 * 6{    6A   �� *DepartmentId+6{   5        5   
   -
   5        $ departmentDataGrid��5       .   . $��419,10,35,10q�5      $��Center=�5       . $	��336��6<   ��5      ��  5         5!      -   5        IdDepartmentColumn��$ Id��5!   Y   	 . $

 Auto 6w    6A   �� *Did+6w     5"      -   5        DepartmentColumn��$ Департамент��5"   ^   $
 * 6s    6?   �� *
Department+6s   5$      �� 5%   
   -   5        $ DeleteDepartment��5%      $��10(�6+   $	��➖��69   
����������#EA1313$��20��6�   $��20��6�   $��760,60,10,426q�6�   �� 5&   
   -   5        $ AddDepartment��5&      $��10(�6(   $	��➕��66   
����������#00AB44$��20��6}   $��20��6�   $��760,10,10,476q�6�    J� RenderTransformOrigin$ 0.489,1.652&�6�   �� 5'   
   -   5        $ UpdateDepartment��5'      $��10(�6D   $
��📝��6R   
����������#FFCF40$��20��6�   $��20��6�   $��760,35,10,451q�6�   $ 
0.46,0.475&�6�   5)      5*      