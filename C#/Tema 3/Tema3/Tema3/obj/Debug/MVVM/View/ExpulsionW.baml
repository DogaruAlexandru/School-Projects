   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5   	   ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5   	        Tema3.MVVM.View.ExpulsionW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.MVVM.View     5   	   8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5   	     � Icon$B  <pack://application:,,,/Resources/Imagines/book-open-flat.png��5	   	   $	��450��5
   	   $	��450��6   $	��450��5   	   $	��450��6    � DataContext 5      &   Tema3.MVVM.ViewModel.ExpulsionVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5!   
   �� $��	0,30,0,20q�5"      $��Center=�5#      $
��Bold"�5$      $��20(�5%      $��	Expulsion��5&      &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ infoGrid��5+      $��1��5)      $��40,20,40,40q�5*         AutoGenerateColumns .  	   
IsReadOnly	 . $��Visible=�5/      ��5-      �� *Pupils+
   Columns
 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ Prenume��53      1  +System.Windows.Controls.DataGridBoundColumn   Binding 54      �� *Item1.FirstName+  56      $
 Nume��57       58      �� *Item1.LastName+  5:      $ Absente��5;       5<      �� *Item2+5>      5?      5@      