   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5   	   ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5   	   R NAttachedCommandBehavior, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehaviorAttachedCommandBehavior 5   	   %    Tema3.MVVM.View.MeansProfessorW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.MVVM.View     5   	   8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5   	   [behaviorFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehavior     5   	     � Icon$B  <pack://application:,,,/Resources/Imagines/book-open-flat.png��5
   	   $	��450��5   	   $	��450��6   $	��450��5   	   $	��450��6    � DataContext 5      +  %Tema3.MVVM.ViewModel.MeansProfessorVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      .+�5$   
   �� $��	0,30,0,20q�5%      $��Center=�5&      $
��Bold"�5'      $��20(�5(      $
��Note��5)      �� 5+   
   $��1��5,      $��Center=�5-      .+�5.      �� $��Incheie media��5/      $��0��50      $��0,0,0,16q�51         MyButtonTheme#��[  52      ��53      �� *FinishMeanCommand+��54      ��  �� ElementName$ infoGrid�� �� Path$ SelectedItem�56      � 58   
   $��2��59      $��Center=�5:      	 � ColumnDefinitions	 5<      �� 5=      $��70 �6#   �� 5>      $	��200��6#    5@      �� 5A      $
��auto �6    .+�5D      �� $
��Bold"�5E      $��14(�5F      $��Materie��5G      �� 5I      -   5        
 ��Name$
 	subjectCB��5J      $��1��5K      $��10(�5L      $��Center=�5M       �� DisplayMemberPath$ Item2��5O      -  'AttachedCommandBehavior.CommandBehavior   Event$ SelectionChanged��5U      ��5N      �� *SubjectsList+   Command 5P      �� *GetPupilsCommand+   CommandParameter 5R      �� $ 	subjectCB��$ SelectedItem.Item1�5U      5V      &   System.Windows.Controls.DataGrid  5X   
   -   5          Name$ infoGrid��5Y      $��3��5Z      $��40,20,40,40q�5[         AutoGenerateColumns .     
IsReadOnly . $��Visible=�5_      ��5]      �� *Pupils+   Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nume��5c      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5d      �� *Item1.FirstName+  5f      $ Prenume��5g       5h      �� *Item1.LastName+  5j      $ Medie��5k       5l      �� *Item2+  5n      $ 	Incheiata��5o       5p      �� *Item3+5r      5s      5t      