   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.MVVM.ViewTema3.MVVM.View  5      ;"clr-namespace:Tema3.MVVM.ViewModelTema3.MVVM.ViewModel  5          Tema3.MVVM.View.HomeUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Tema3.MVVM.View     5      8	viewModel"clr-namespace:Tema3.MVVM.ViewModel     5      -   5          >�Name$  login��5      
�����_� � DataContext 5      !  Tema3.MVVM.ViewModel.HomeVM  5   
   .��5      � $��Center=�5   	   $��Center=�5   	    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Nume de utilizator��5       $��0,0,20,0q�5!      $
��Bold"�5"      �� 5$   
   -   5         ��Name$ username��5%      $��1��5&      $��Center=�5'      $	��160��5(      $��24��5)      �� 5+   
   $��1��5,      $��Parola��5-      $��0,0,20,0q�5.      $
��Bold"�5/      G� 51   
   -   5         G�Name$ password��52      $��1��53      $��1��54      $��Center=�55      $	��160��56      $��24��57      �� 59   
   -   5         ��Name$ 	logInMode��5:      $��0,30,0,0q�5;      $��2��5<      .@�5>      �� $��Admin��5?      �� 5A      $��Profesor��5B      �� 5D      $��	Diriginte��5E      �� 5G      $
��Elev��5H      5I      �� 5K   
   $��0,30,0,0q�5L      $��1��5M      $��2��5N      $��Autentifica��5O      $
��Bold"�5P      ��5Q      �� *LogInClicked+��5R      ��  �� ElementName$ login����5T      �� 5U       �� 
TargetType" ��5V      	 �� Triggers	 5W      �� 5X      
 �� Binding
 5Y      ��  �� Path$ SelectedItem�$ 	logInMode�� �� Value 5[      Z� .a�5]      ��  �� Property � {� �� Value .  5_   !   5`      5b      5d      5e      5f      