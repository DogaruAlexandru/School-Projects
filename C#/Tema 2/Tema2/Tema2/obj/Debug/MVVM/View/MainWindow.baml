   M S B A M L   `   `   `  ����@  <Tema2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema2.MVVM.ViewTema2.MVVM.View  5   	   ;"clr-namespace:Tema2.MVVM.ViewModelTema2.MVVM.ViewModel  5   	        Tema2.MVVM.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema2.MVVM.View     5   	   1VM"clr-namespace:Tema2.MVVM.ViewModel     5   	     � Title$  Checkers��5	   	    � SizeToContent$ WidthAndHeight=�5
   	    � 
ResizeMode$ NoResize=�5   	    � Icon$% ..\..\Resources\Images\Icon.jpg��5   	    � DataContext 5      !   Tema2.MVVM.ViewModel.MainVM  5   
    � 	Resources 5         menuViewTemplate �� DataType%   Tema2.MVVM.View.MenuUserControl  gameViewTemplate%   Tema2.MVVM.View.GameUserControl  aboutViewTemplate&    Tema2.MVVM.View.AboutUserControl  loadGameViewTemplate)   #Tema2.MVVM.View.LoadGameUserControl��%   &	        &	 6     &	 l     &	 �     �� 5   
   "  5      .R�5        5      �� 5   
   "  5      .R�5        5      �� 5   
   "  5       .R�5!        5"      �� 5$   
   "  5&      .R�5'        5(      5)      .��5*      � .+�5+   
   �� ��5,      �� ��5-      �� 5.       �� 
TargetType" ��5/      .�50      ��  �� Property � ��	 �� Value#	 [  52      
 �� Triggers
 53      �� 54       �� Binding 55      �� *
SwitchView+ �� Value 156      .a�57      ��  � ��#	 [ 59   !   5:      �� 5;       5<      �� *
SwitchView+ 25=      .a�5>      ��  � ��#	 [ 5@   !   5A      �� 5B       5C      �� *
SwitchView+ 35D      .a�5E      ��  � ��#	 [ 5G   !   5H      5J      5L      5M      5N      