   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5   	   ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5   	   R NAttachedCommandBehavior, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehaviorAttachedCommandBehavior 5   	   1    +Tema3.MVVM.View.TeachingMaterialsProfessorW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.MVVM.View     5   	   8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5   	   [behaviorFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehavior     5   	     � Icon$B  <pack://application:,,,/Resources/Imagines/book-open-flat.png��5
   	   $	��450��5   	   $	��450��6   $	��450��5   	   $	��450��6    � DataContext 5      7  1Tema3.MVVM.ViewModel.TeachingMaterialsProfessorVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       .+�5#   
   �� $��	0,30,0,20q�5$      $��Center=�5%      $
��Bold"�5&      $��20(�5'      $��Materiale Didactice��5(      �� 5*   
   $��1��5+       �� Orientation$ 
Horizontal=�5,      $��Center=�5-      .+�5/      �� $��Modifica��50      $	��100��51         MyButtonTheme#��[  52      ��53      �� *ModifyCommand+��54      ��  �� ElementName$ infoGrid��	 �� Path$	 SelectedItem��� 57      $��Sterge��58      $	��100��59      #��[  5:      ��5;      �� *RemoveCommand+��5<      �� $ infoGrid��$	 SelectedItem�5>      &   System.Windows.Controls.DataGrid  5@   
   -   5        
  Name$
 infoGrid��5A      $��2��5B      $��40,20,40,40q�5C         AutoGenerateColumns .     
IsReadOnly . $��Visible=�5G      ��5E      �� *
Subjects+   Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ Materie��5K      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5L      �� *Item1.SubjectName+  5N      $
  An ��5O       5P      �� *
Item1.Year+  5R      $ Semestru��5S       5T      �� *Item1.Semester+  5V      $ Materiale didactice��5W       5X      �� *Item2.Teaching_materials+5Z      5\      5]      