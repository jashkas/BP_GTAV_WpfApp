﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace BP_GTAV_WpfApp
{
    internal class BpFile
    {
        public List<BpData> data;

        private readonly string fileName = "bp_gtav_data.json";

        public BpFile()
        {
            data = new List<BpData>();
            //Write();  // для первого запуска создается файл
            Read();
        }

        // Чтение данных
        public void Read()
        {
            // Проверяем существует ли файл
            if (!System.IO.File.Exists(fileName))
            {
                // Если файла нет - создаем его с пустым массивом
                System.IO.File.WriteAllText(fileName, "[]");
            }

            // Читаем данные из файла
            using (StreamReader file = System.IO.File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                data = (List<BpData>)serializer.Deserialize(file, typeof(List<BpData>));
            }
            // Если в списке есть элементы
            if (data.Count > 0) 
            {
                // Узнаем общее количество бипишек
                BpData lastData = data.Last(); // взяли последний элемент
                BpData bpData = new BpData();  // создали новый
                bpData.Bp = lastData.Bp; // записываем в новый количество бипишек
                // Получаем индекс записи с такой же датой
                var dateExistIndex = data.FindIndex(d => d.Date == bpData.Date);
                if (dateExistIndex == -1)
                {
                    data.Add(bpData);
                }
            }
            else
            {
                // В пустой список добавляем данные текущего дня
                data.Add(new BpData());
            }
        }

        // Сохранение данных
        public void Write()
        {
            using (StreamWriter fs = new StreamWriter(fileName))
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(fs, data);
                }
            }
        }

        // Изменение данных
        public BpData Get(string date)
        {
            var selected = from d in data where d.Date == date select d;

            List<BpData> bpd = selected.ToList();
            BpData thisBpData = bpd[0];

            return thisBpData;
        }
        public BpData Get(int index)
        {
            return data[index];
        }
        public void Change(BpData bpData)
        {
            // Получаем индекс записи с такой же датой
            var dateExistIndex = data.FindIndex(d => d.Date == bpData.Date);
            if (dateExistIndex != -1)
            {
                // Редактируем ее при наличии
                data[dateExistIndex] = bpData;
            }
            else
            {
                data.Add(bpData);
            }
        }
        public void ChangeIndex(int index, BpData bpData)
        {
            data.RemoveAt(index);
            data.Insert(index, bpData);
        }
    }
}
