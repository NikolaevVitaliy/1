﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;


namespace View
{
    public partial class SalaryForm : Form
    {
        public SalaryForm()
        {
            InitializeComponent();
        }

    

        //Кнопка добавления строки с данными о человеке в список через форму создания
        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            CreatingForm AddForma1 = new CreatingForm();
            if (AddForma1.ShowDialog() == DialogResult.OK)
            {
                var person = AddForma1.Person;
                this.dataGridViewPerson.Rows.Add(person.FirstName, person.LastName, person.DateOfReceipt, person.GetSalary());
                PersonList.listPerson.Add(person);
            }
        }

        //Кнопка удаления строки с данными о человеке из списка 
        private void buttonRemovePerson_Click(object sender, EventArgs e)
        {
            int removeIndex = dataGridViewPerson.CurrentCell.RowIndex;
            if (dataGridViewPerson.Rows.Count == 0)
            {
                MessageBox.Show("Список пуст!");
            }
            dataGridViewPerson.Rows.RemoveAt(removeIndex);
            PersonList.listPerson.RemoveAt(removeIndex);
        }
        //Кнопка изменения данных в строке списка через форму создания фигуры
        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (dataGridViewPerson.Rows.Count == 0)
            {
                MessageBox.Show("Список пуст!");
            }
            else
            {
                CreatingForm AddModify = new CreatingForm();
                int modIndex = dataGridViewPerson.CurrentCell.RowIndex;
                AddModify.Person = PersonList.listPerson[modIndex];
                if (AddModify.ShowDialog() == DialogResult.OK)
                {
                    var newPerson = AddModify.Person;
                    PersonList.listPerson.Insert(dataGridViewPerson.SelectedCells[0].RowIndex, newPerson);
                    PersonList.listPerson.RemoveAt(dataGridViewPerson.SelectedCells[0].RowIndex + 1);
                    dataGridViewPerson.Rows.Clear();
                    foreach (var data in PersonList.listPerson)
                    {
                        dataGridViewPerson.Rows.Add(data.FirstName, data.LastName, data.DateOfReceipt, data.GetSalary());
                    }

                }

            }

        }
        //Поиск данных по фамилия человека
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewPerson.ClearSelection();
            for (int i = 0; i < dataGridViewPerson.Rows.Count; i++)
            {
                dataGridViewPerson.Rows[i].Visible = false;
                if (dataGridViewPerson[0, i].Value.ToString() == textBoxSearch.Text)
                {
                    dataGridViewPerson.Rows[i].Visible = true;
                }
            }
        }

  

       




    }

}