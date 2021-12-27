using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using REALtor1._2.Data.Models;

namespace REALtor1._2.Data
{
    public class DbObjects
    {
        public static void Initial(DbContent content)
        {
            if (!content.Person.Any())
                content.Person.AddRange(People.Select(content => content.Value));
            if (!content.House.Any())
                content.House.AddRange
                    (
                    new House
                    {
                        Address = "ул. Счастливая д.3 кв.22",
                        Area = "Индустриальный",
                        Available = true,
                        hotWater = true, 
                        coldWater = true, 
                        electricity = true,
                        gas = true,
                        CountOfRooms = 3,
                        Despription = "Прекрасная трехкомнатная квартира на 2 этаже ЖК Улыбка, рядом детский сад, школа, гипермаркет Пятерочка, 10 минут до остановок общественного транспорта",
                        Img = "/img/house1.jpg",
                        Name = "ЖК Улыбка",
                        Price = 3000000,
                        Square = 61.2,
                        StatusOfHome = "Новостройка",
                        Seller = People["Шарапов Петр Игоревич"]
                    },
                    new House
                    {
                        Address = "ул. Пушкина д.12 кв.24",
                        Area = "Октябрьский",
                        Available = true,
                        hotWater = true, 
                        coldWater = true,
                        electricity = true,
                        gas = true,
                        CountOfRooms = 1,
                        Despription = "Уютная однокомнатная квартира, в шаговой доступности остановкки общественного транспорта, гипермаркет Магнит, санаторий Ласточка",
                        Img = "/img/house2.jpg",
                        Name = "Квартира на ул.Пушкина",
                        Price = 1200000,
                        Square = 32,
                        StatusOfHome = "Многоэтажный дом советстких времен",
                        Seller = People["Григорьев Михаил Алексеевич"]
                    },
                    new House
                    {
                        Address = "ул. Карла Маркса д.45",
                        Area = "Первомайский",
                        Available = true,
                        hotWater = true, 
                        coldWater = true,
                        electricity = true,
                        gas = false,
                        CountOfRooms = 6,
                        Despription = "Двухэтажный, рядом детский сад, автобусная остановка. Просторный, недавно был ремонт",
                        Img = "/img/house3.jpg",
                        Name = "Частный двухэтажный дом на ул. Карла Маркса",
                        Price = 5500000,
                        Square = 97.6,
                        StatusOfHome = "Частный дом",
                        Seller = People["Русских Роза Викторовна"]
                    },
                    new House
                    {
                        Address = "ул. Петровская д.10 кв.42",
                        Area = "Индустриальный",
                        Available = false,
                        hotWater = true,
                        coldWater = true, 
                        electricity = true,
                        gas = true,
                        CountOfRooms = 4,
                        Despription = "Квартира на 5 этаже для большой семьи, рядом детский сад, школа, университет, больница, библиотека, 20 минут пешком от остановок общественного транспорта",
                        Img = "/img/house4.jpg",
                        Name = "ЖК Петр",
                        Price = 4100000,
                        Square = 72.2,
                        StatusOfHome = "Новостройка",
                        Seller = People["Русских Роза Викторовна"]
                    },
                    new House
                    {
                        Address = "ул. Лесная р.2 №23",
                        Area = "Первомайский",
                        Available = true,
                        hotWater = false,
                        coldWater = false,
                        electricity = true,
                        gas = false,
                        CountOfRooms = 1,
                        Despription = "Отапливаемый, въезд/выезд без наклона, уверенно вмещает легковой автомобиль средних габаритов",
                        Img = "/img/house5.jpg",
                        Name = "Гараж на ул.Лесная",
                        Price = 160000,
                        Square = 22,
                        StatusOfHome = "Гаражное помещение",
                        Seller = People["Григорьев Михаил Алексеевич"]
                    },
                    new House
                    {
                        Address = "ул. Заводская д.9",
                        Area = "Октябрьский",
                        Available = true,
                        hotWater = true, 
                        coldWater = true,
                        electricity = true, 
                        gas = false,
                        CountOfRooms = 4,
                        Despription = "Старый деревянный дом, обшит сайдингом, 2 минут до остановок общественного транспорта, больница, санаторий, подойдет для людей с ограниченным бюджетом, газ отсутствует",
                        Img = "/img/house6.jpg",
                        Name = "Дом на ул. Заводская",
                        Price = 400000,
                        Square = 55.1,
                        StatusOfHome = "Старый ветхий дом",
                        Seller =  People["Русских Роза Викторовна"]
                    }
                    );
            content.SaveChanges();
        }
        private static Dictionary<string, Person> people;
        public static Dictionary<string,Person> People {
            get
            {
                if (people == null)
                {
                    var list = new Person[]
                    {
                        new Person {Fio ="Шарапов Петр Игоревич",Email="sharapovP@mail.ru",NumberOfPhone="88005553535", Status="владелец"},
                        new Person {Fio ="Григорьев Михаил Алексеевич",Email="mihaDestroyer@mail.ru",NumberOfPhone="79139432323", Status="владелец"},
                        new Person {Fio = "Мирная Инга Геннадьевна",Email="inga@mail.ru",NumberOfPhone="89459342221", Status="покупатель"},
                        new Person {Fio = "Орлов Константин Дмитриевич",Email="orlov2012@mail.ru",NumberOfPhone="73452347712", Status="покупатель"},
                        new Person {Fio ="Ветров Алмаз Тимурович" ,Email="dimonDd@mail.ru",NumberOfPhone="89090657455", Status="покупатель"},
                        new Person {Fio ="Русских Роза Викторовна",Email="rozaMimoza@mail.ru",NumberOfPhone="84442341121", Status="владелец"}
                    };
                    people = new Dictionary<string, Person>();
                    foreach (var e in list)
                        people.Add(e.Fio, e);
                }
                return people;
            }
         }
    }
}
