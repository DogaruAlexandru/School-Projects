   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5   	   ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5   	   R NAttachedCommandBehavior, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehaviorAttachedCommandBehavior 5   	   .    (Tema3.MVVM.View.AbsencesHomeroomTeacherW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.MVVM.View     5   	   8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5   	   [behaviorFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehavior     5   	     � Icon$B  <pack://application:,,,/Resources/Imagines/book-open-flat.png��5
   	   $	��450��5   	   $	��450��6   $	��450��5   	   $	��450��6    � DataContext 5      4  .Tema3.MVVM.ViewModel.AbsencesHomeroomTeacherVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      .+�5$   
   �� $��	0,30,0,20q�5%      $��Center=�5&      $
��Bold"�5'      $��20(�5(      $��Absente��5)      �� 5+   
   $��1��5,       �� Orientation$ 
Horizontal=�5-      $��Center=�5.      $��0,0,0,20q�5/      .+�51      �� $��	Motiveaza��52      $
��auto��53         MyButtonTheme#��[  54      ��55      �� *MotivateCommand+��56      ��  �� ElementName$ infoGrid��	 �� Path$	 SelectedItem�58      � 5:   
   $��2��5;      $��Center=�5<      
 � ColumnDefinitions
 5>      �� 5?      $��70 �6#   �� 5@      $	��200��6#    5B      �� 5C      $
��auto �6    �� 5D      $
��auto �6    .+�5G      �� $
��Bold"�5H      $��14(�5I      $
��Elev��5J      �� 5L      $��1��5M      $
��Bold"�5N      $��14(�5O      $	��Tip��5P      �� 5R      -   5         ��Name$ pupilCB��5S      $��1��5T      $��10(�5U      $��Center=�5V       �� SelectedIndex$ 0��5W       �� DisplayMemberPath$ Item2��5Y      -  'AttachedCommandBehavior.CommandBehavior   Event$ SelectionChanged��5^      ��5X      �� *
PupilsList+   Command 5Z      �� *PupilCommand+   CommandParameter 5\      �� $ pupilCB��$	 SelectedItem.Item1�5^      �� 5`      -   5        $ stateCB��5a      $��1��5b      $��1��5c      $��10(�5d      $ 0��5e      $��Center=�5f      $ SelectionChanged��5k       5g      �� *StateCommand+ 5i      �� $ stateCB��$
	 Text�.@�5m      �� $��Toate��6   �� 5n      $��
Nemotivate��6   5o      5p      � 5r   
   $��3��5s      $��40,20,40,40q�5t       5v      �� 5w      �� 5x      $
��auto �6    .+�5{      &   System.Windows.Controls.DataGrid  -   5          Name$ infoGrid��5|         AutoGenerateColumns .     
IsReadOnly . $��Visible=�5�      ��5~      �� *
Absences+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Elev��5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *Item2+  5�      $
 Data��5�       5�      �� *Item3+  5�      $	 Tip��5�       5�      �� *Item4+5�      �� 5�      $��1��5�      
����ح�$��1q�5�      
�������$��Center=�5�      $��Center=�5�      $��10(�5�      $
��Bold"�5�      ��5�      �� *Count+5�      5�      5�      