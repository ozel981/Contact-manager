   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   H DWpfAppZadanie, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfAppZadanieWpfAppZadanie 5   	      WpfAppZadanie.NewContact   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -localclr-namespace:WpfAppZadanie     5   	     � Title$  
NewContact��5	   	   $	��450��6   $	��400��6)    � 
ResizeMode$ NoResize=�65    � WindowStyle$
 none=�6K   $��3q�6^    � WindowStartupLocation$ CenterScreen=�6r    � 	Resources 5
       
  GENDER S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  errorTemplate	 �� CornerRadius
 � ToolTip��%�  &	        &	 m     S� 5   
   $ 	GetValues��5      "  6$    5      M� 5      $ local:GENDER��6   5      �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��2q�6,   ._�5      �� 5      �� 5      $��2q�6   $	 45��6$   ._�5      �� $	�� X ��6    $��14(�6+   $��DemiBold"�69   
���  ��
�������
 5      _� 5      $y�Visible=�6&   .��5   "   �� ��6,   �� *[0].ErrorContent+6P   5      5      5      5      5       5!      .��5"      �  � RowDefinitions 5#   
   �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*       � ColumnDefinitions 5,   
   �� 5-      �� 5.      .+�50   
   �� $��30(�6   $��Add new contact��6"   $��2��69   $��Center=�6M   $��Center=�6j   �� 51   
   $��16(�6   $��Name:��6"   $��1��6/   $��Center=�6<   $��Center=�6Y   �� 52   
   $��16(�6   $��Surname:��6"   $��2��62   $��Center=�6?   $��Center=�6\   �� 53   
   $��16(�6   $��Email:��6"   $��3��60   $��Center=�6=   $��Center=�6Z   �� 54   
   $��16(�6   $��Phone:��6"   $��4��60   $��Center=�6=   $��Center=�6Z   �� 55   
   $��16(�6   $��Gender:��6"   $��5��61   $��Center=�6>   $��Center=�6[   �� 56   
   -   5        $��20q�56      $��6��6   $��0��6*   .��6Q   Add contact6^   �� 57   
   -   5        $��20q�57      $��6��6   $��1��6*   .��6O   Cancle6W   �� 58   
   -   5        $
��name��58      $��1��6   $��1��6+   $��20q�6;    =� ErrorTemplate# [ 6d   ��6G   �� *ContactName+6d   �� 59   
   -   5        $��surname��59      $��2��6!   $��1��6.   $��20q�6>   # [ 6j   ��6J   �� *ContactSurname+6j   �� 5:   
   -   5        $
��mail��5:      $��3��6   $��1��6+   $��20q�6;   # [ 6e   ��6G   �� *ContactEmail+6e   �� 5;   
   -   5        $��phone��5;      $��4��6   $��1��6,   $��20q�6<   # [ 6f   ��6H   �� *ContactPhone+6f   �� 5=   
   -   5        $��gender��5=      $��5��6!   $��1��6.   $��20q�6>    �� SelectedIndex$ 0��6J   ��6\   ��  �� Source# [  5>      5?      5@      