   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5   	   ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5   	   R NAttachedCommandBehavior, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehaviorAttachedCommandBehavior 5	   	   !    Tema3.MVVM.View.AdminPupilW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.MVVM.View     5   	   8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5   	   [behaviorFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehavior     5	   	   -   5          �Name$  adminPupilW��5   	    � Icon$B <pack://application:,,,/Resources/Imagines/book-open-flat.png��5   	   $	��600��5   	   $	��600��6   $	��450��5   	   $	��450��6    � DataContext 5      '  !Tema3.MVVM.ViewModel.AdminPupilVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      .+�5%   
   �� $��	0,30,0,20q�5&      $��Center=�5'      $
��Bold"�5(      $��20(�5)      $��Elevi��5*      �� 5,   
   $��1��5-       �� Orientation$ 
Horizontal=�5.      $��Center=�5/      $��0,0,0,20q�50      .+�52      �� $��Adauga��53      $	��100��54         MyButtonTheme#��[  55      ��56      �� *
AddCommand+��57      �� 	 �� ElementName$	 classCB��
 �� Path$
 SelectedItem��� 5:      $��Modifica��5;      $	��100��5<      #��[  5=      ��5>      �� *ModifyCommand+��5?      �� $	 classCB��$
 SelectedItem��� 5B      $��Sterge��5C      $	��100��5D      #��[  5E      ��5F      �� *DeleteCommand+5G      � 5I   
   $��2��5J      $��Center=�5K       � ColumnDefinitions 5M      �� 5N      $
��auto �6#   �� 5O       5Q      �� 5R      $
��auto �6    �� 5S      $
��auto �6    �� 5T      $
��auto �6    �� 5U      $
��auto �6    �� 5V      $
��auto �6    �� 5W      $
��auto �6    �� 5X      $
��auto �6    .+�5[      �� $��1��5\      $	��240��5]      ��5^      �� *
LastName+�� 5`      $��1��5a      $��1��5b      $	��240��5c      ��5d      �� *	FirstName+�� 5f      -   5         ��Name$ classCB��5g      $��1��5h      $��2��5i      $	��240��5j      $��8(�5k       �� DisplayMemberPath$ 	ClassName��5m      ��5l      �� *	Classes+5m      �� 5o      $��1��5p      $��3��5q      $	��240��5r      ��5s      �� *
Username+�� 5u      $��1��5v      $��4��5w      $	��240��5x      ��5y      �� *
Password+�� 5{      $��1��5|      $��5��5}      $	��240��5~      ��5      �� *PhoneNumber+�� 5�      $��1��5�      $��6��5�      $	��240��5�      ��5�      �� *Email+�� 5�      $
��Bold"�5�      $��14(�5�      $
��Nume��5�      �� 5�      $��1��5�      $
��Bold"�5�      $��14(�5�      $��Prenume��5�      �� 5�      $��2��5�      $
��Bold"�5�      $��14(�5�      $��Clasa��5�      �� 5�      $��0,0,20,0q�5�      $��3��5�      $
��Bold"�5�      $��14(�5�      $��Nume de utilizator��5�      �� 5�      $��4��5�      $
��Bold"�5�      $��14(�5�      $��Parola��5�      �� 5�      $��5��5�      $
��Bold"�5�      $��14(�5�      $��Numar de telefon��5�      �� 5�      $��6��5�      $
��Bold"�5�      $��14(�5�      $��Email��5�      5�      � 5�   
   $��40,20,40,40q�5�      $��3��5�       5�      �� 5�      �� 5�      $
��auto �6    .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ infoGrid��5�         AutoGenerateColumns .     
IsReadOnly . $��Visible=�5�      -  'AttachedCommandBehavior.CommandBehavior   Event$ SelectionChanged��5�      ��5�      �� *Pupils+   Command 5�      �� *SelectCommand+   CommandParameter 5�      �� $	 adminPupilW��   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nume��5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *Item1.FirstName+  5�      $ Prenume��5�       5�      �� *Item1.LastName+  5�      $ Clasa��5�       5�      �� *Item4.ClassName+  5�      $ Nume de utilizator��5�       5�      �� *Item2+  5�      $ Parola��5�       5�      �� *Item3+  5�      $ Numar de telefon��5�       5�      �� *Item1.PhoneNumber+  5�      $ Email��5�       5�      �� *Item1.Email+5�      5�      5�      5�      