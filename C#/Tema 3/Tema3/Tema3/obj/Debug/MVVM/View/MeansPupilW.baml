   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5   	   ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5   	   !    Tema3.MVVM.View.MeansPupilW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.MVVM.View     5   	   8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5   	     � Icon$B  <pack://application:,,,/Resources/Imagines/book-open-flat.png��5	   	   $	��450��5
   	   $	��450��6   $	��450��5   	   $	��450��6    � DataContext 5      '  !Tema3.MVVM.ViewModel.MeansPupilVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5    
   � $��0��5!       5#      �� 5$      $
��auto �6    �� 5%      .+�5(      �� $��	0,30,0,20q�5)      $��Center=�5*      $
��Bold"�5+      $��20(�5,      $��Medii��5-      �� 5/      $��1��50      $��3q�51      $��
30,0,30,70q�52       �� SelectionMode$ Single=�53      ��54      �� *Means+ �� View 56      �� 57      	 �� AllowsColumnReorder	 .  .P�5:      �� 
 �� Width$

 auto��5;      $��Materie��5=       �� DisplayMemberBinding 5<      �� *SubjectName+5=      �� 5?      $

 auto��5@      $
�� An ��5B       5A      �� *Year+5B      �� 5D      $

 auto��5E      $��Semestru��5G       5F      �� *
Semester+5G      �� 5I      $

 auto��5J      $
��Nota��5L       5K      �� *
MeanMark+5L      5M      ��5P      �� 5Q       �� Color$ 	#CCEAF5FF��6&   5S      5T      5U      5V      