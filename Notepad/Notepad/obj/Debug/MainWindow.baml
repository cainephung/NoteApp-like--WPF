   M S B A M L   `   `   `  ????B  >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad  5   	       Notepad.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Notepad     5   	   -   5          ? Title$  Untitled - Notepad??5   	   $	??460??6$   $	??800??61    J? CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$  ApplicationCommands.SaveAs??5      5   %   .??5      ? $??0,0,0,0q?6    ? ColumnDefinitions 5   
   ?? 5      $
??422* ?6   ?? 5      $	??48* ?6   ?? 5      $
??323* ?6   ?? 5      $??7* ?6    ? RowDefinitions 5   
   ?? 5      $??236.64 ?6   ?? 5      $??163.36 ?6   ?? 5      $??30 ?6   .+?5   
   o? $??20??6   $	??Top=?6   $??4??63   .@?5       m? $
??File??6   .@?5!      m? -   5        $	??New??5!      6)   m? 5#      -   5        $
??Open??5#      6*   m? 5$      $??Save As??6    m? Command$  ApplicationCommands.SaveAs??5%       m? CommandTarget 5&      ??  ?? ElementName$ txtWorkarea??m? 5'      -   5        $
??Exit??5'      6)   5)      m? 5+      $
??Edit??6   .@?5,      m? $	??Cut??6   $ ApplicationCommands.Cut??5-       5.      ?? $ txtWorkarea??m? 5/      $
??Copy??6   $ ApplicationCommands.Copy??50       51      ?? $ txtWorkarea??m? 52      $??Paste??6   $ ApplicationCommands.Paste??53       54      ?? $ txtWorkarea??55      m? 57      $
??Help??6   .@?58      m? -   5        $??About??58      6*   59      5;      ?? 5=   
   -   5        $??txtWorkarea??5=      $??	10,20,5,0q?6%    ?? TextWrapping$
 Wrap=?68   $?? ??6L   $	??Top=?6T   $	??380??6l   	 ?? AcceptsReturn	 . "
 ?? VerticalScrollBarVisibility$

 Auto=?6?   $??3??6?   $??2??6?   ?? 5?   
   $??Right=?6M   $??2??6i   $	??Top=?6v   $??2??6?   $??2??6?   ??6   ?? $ txtWorkarea?? ?? Path$ Text.Length?6?   5A      5C      