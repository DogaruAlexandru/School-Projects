   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5   	   ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5   	   -    'Tema3.MVVM.View.TeachingMaterialsPupilW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.MVVM.View     5   	   8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5   	     � Icon$B  <pack://application:,,,/Resources/Imagines/book-open-flat.png��5	   	   $	��450��5
   	   $	��450��6   $	��450��5   	   $	��450��6    � DataContext 5      3  -Tema3.MVVM.ViewModel.TeachingMaterialsPupilVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5    
   � $��0��5!       5#      �� 5$      $
��auto �6    �� 5%      .+�5(      �� $��	0,30,0,20q�5)      $��Center=�5*      $
��Bold"�5+      $��20(�5,      $��Materiale didactice��5-      �� 5/      -   5         ��Name$ 	materials��50      $��1��51      $��3q�52      $��	30,0,30,0q�53       �� SelectionMode$ Single=�54      ��55      �� *TeachingMaterials+	 �� View	 57      �� 58      
 �� AllowsColumnReorder
 .  .P�5;      ��  �� Width$
 auto��5<      $��Materie��5>       �� DisplayMemberBinding 5=      �� *SubjectName+5>      �� 5@      $
 auto��5A      $
�� An ��5C       5B      �� *Year+5C      �� 5E      $
 auto��5F      $��Semestru��5H       5G      �� *
Semester+5H      5J      ��5M      �� 5N       �� Color$ 	#CCEAF5FF��6&   5P      5Q      �� 5S   
   $��20,20,20,40q�5T      $��1��5U       �� Orientation$ 
Horizontal=�5V      $��Center=�5W      .+�5Y      �� $��Deschide��5Z      ��5[      �� *Open+��5\      ��  �� ElementName$ 	materials�� �� Path$ SelectedItem���5_      �� 5`       �� 
TargetType" ��5a         MyButtonTheme �� BasedOn# [  5b       �� Triggers 5d      �� 5e       �� Binding 5f   !   �� $ 	materials��$ SelectedItem� �� Value 5h   !   Z� .a�5j   "   ��  �� Property � {� �� Value .  6>   5k      5m      5o      5p      5q      5r      