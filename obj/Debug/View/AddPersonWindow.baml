   M S B A M L   `   `   `  ����S  ORKSI.EduPractice_EF_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RKSI.EduPractice_EF_MVVM.ViewRKSI.EduPractice_EF_MVVM.View  5   	   W0clr-namespace:RKSI.EduPractice_EF_MVVM.ViewModel"RKSI.EduPractice_EF_MVVM.ViewModel  5   	   3    -RKSI.EduPractice_EF_MVVM.View.AddPersonWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:RKSI.EduPractice_EF_MVVM.View     5   	   Clocal10clr-namespace:RKSI.EduPractice_EF_MVVM.ViewModel     5   	     � Title$  AddPersonWindow��5	   	   $��341.167��6!   $	��278��62    � DataContext 5
      4  .RKSI.EduPractice_EF_MVVM.ViewModel.AddPersonVM  5   
   .��5      � .+�5   
   �� $��Шифр��6   $
��Left=�6   $��	10,10,0,0q�6:   $	��Top=�6M   �� 5   
   $
��Left=�6   $��23��6-   $��	10,36,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��241��6x   ��5      �� *Cypher+�� 5   
   $��ИНН��6   $
��Left=�6   $��	10,59,0,0q�69   $	��Top=�6L   �� 5   
   $
��Left=�6   $��23��6-   $��	10,85,0,0q�69   $
 Wrap=�6L   $	��Top=�6`   $	��241��6x   ��5      �� *Inn+�� 5   
   $��Тип��6   $
��Left=�6   $��
10,108,0,0q�69   $	��Top=�6M   �� 5   
   $
��Left=�6   $��23��6-   $��
10,134,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $	��241��6y   ��5      �� *Type+�� 5   
   $%��Дата регистрации��6   $
��Left=�6+   $��
10,157,0,0q�6F   $	��Top=�6Z   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6   $��
10,183,0,0q�60   $	��Top=�6D   $	��241��6\      SelectedDate 5      �� *Date+   Text 63   �� *DefaultDate+�� 5   
   $.��(Данные пользователя...��6   $
��Left=�61   $��
10,207,0,0q�6L   $	��Top=�6`   �� 5   
   $
��Left=�6   $��
10,233,0,0q�6.   $	��Top=�6B   $	��241��6Z   ��5      �� *
Citizens+ �� SelectedItem 64   �� *SelectedCitizen+�� 5   
   -   5        $��Добавить��5      $
��Left=�6$   $��
10,260,0,0q�6?   $	��Top=�6S   $	��241��6k   $��23��6w   ��5      �� *	AddPerson+6/   5      5       