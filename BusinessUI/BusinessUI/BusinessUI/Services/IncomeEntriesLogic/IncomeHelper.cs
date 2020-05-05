using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Android.Renderscripts;
using BusinessUI.Models;
using BusinessUI.ViewModels;
using Microcharts;
using SkiaSharp;

namespace BusinessUI.Services.IncomeEntriesLogic
{
    public sealed class IncomeHelper
    {
        private Login Login { get; }
        private IncomeAdapter IncomeAdapter { get; }
        public IncomeHelper()
        {
            this.Login = MainContext.Login;
        }

        public Entry[] ParseModelToEntry(IncomeModel[] models)
        {
            List<Entry> entries = new List<Entry>(models.Length);

            foreach (IncomeModel model in models)
            {
                entries.Add(new Entry(value:model.Value)
                    {
                        Color = model.Color,
                        Label = model.Value.ToString(CultureInfo.InvariantCulture),
                        TextColor = model.Color
                    });
            }

            return entries.ToArray();
        }

        public Tuple<Entry[], Entry[]> GetIncome(IncomeType type)
        {
            switch (type)
            {
                case IncomeType.Year:
                    return this.GetYearlyEntries();
                case IncomeType.Day:
                    return this.GetDaily();
                case IncomeType.Month:
                    return this.GetMonthly();
                case IncomeType.Week:
                    return this.GetWeekly();
                default:
                    return null;
            }
        }

        private Tuple<Entry[], Entry[]> GetYearlyEntries()
        {
            //TODO:Get entries from the adapter 

            var incomesEntries = new Entry[]
            {
                new Entry(2300)
                {
                    Label = "Jan",
                    ValueLabel = "2300",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(1294)
                {
                    Label = "Feb",
                    ValueLabel = "1294",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(4721)
                {
                    Label = "Mar",
                    ValueLabel = "4721",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(984)
                {
                    Label = "Apr",
                    ValueLabel = "984",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(1039)
                {
                    Label = "May",
                    ValueLabel = "1039",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(2089)
                {
                    Label = "Jun",
                    ValueLabel = "2089",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(1000)
                {
                    Label = "Jul",
                    ValueLabel = "1000",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(5000)
                {
                    Label = "Aug",
                    ValueLabel = "5000",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(4300)
                {
                    Label = "Sep",
                    ValueLabel = "4300",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(1245)
                {
                    Label = "Oct",
                    ValueLabel = "1245",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(834)
                {
                    Label = "Nov",
                    ValueLabel = "834",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(300)
                {
                    Label = "Dec",
                    ValueLabel = "300",
                    Color = SKColor.Parse("#b455b6")
                }
            };
            var expensesEntries = new Entry[]
            {
                new Entry(1245)
                {
                    Label = "Jan",
                    ValueLabel = "1245",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(634)
                {
                    Label = "Feb",
                    ValueLabel = "634",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(2341)
                {
                    Label = "Mar",
                    ValueLabel = "2341",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(984)
                {
                    Label = "Apr",
                    ValueLabel = "984",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(1039)
                {
                    Label = "May",
                    ValueLabel = "1039",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(2089)
                {
                    Label = "Jun",
                    ValueLabel = "2089",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(754)
                {
                    Label = "Jul",
                    ValueLabel = "754",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(1532)
                {
                    Label = "Aug",
                    ValueLabel = "1532",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(2341)
                {
                    Label = "Sep",
                    ValueLabel = "2341",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(1245)
                {
                    Label = "Oct",
                    ValueLabel = "1245",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(345)
                {
                    Label = "Nov",
                    ValueLabel = "345",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(123)
                {
                    Label = "Dec",
                    ValueLabel = "123",
                    Color = SKColor.Parse("#b455b6")
                }
            };

            return new Tuple<Entry[], Entry[]>(incomesEntries, expensesEntries);
        }

        private Tuple<Entry[], Entry[]> GetMonthly()
        {
            //TODO:Get entries from the adapter 

            var incomeEntries = new Entry[]
            {
                new Entry(9842)
                {
                    Label = "0-5",
                    ValueLabel = "9842",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(2934)
                {
                    Label = "5-10",
                    ValueLabel = "2934",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(5921)
                {
                    Label = "10-15",
                    ValueLabel = "5921",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(10000)
                {
                    Label = "15-20",
                    ValueLabel = "10000",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(4125)
                {
                    Label = "20-25",
                    ValueLabel = "4125",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(6346)
                {
                    Label = "25-30",
                    ValueLabel = "6346",
                    Color = SKColor.Parse("#b455b6")
                }
            };
            var expenseEntries = new Entry[]
            {
                new Entry(1234)
                {
                    Label = "0-5",
                    ValueLabel = "1234",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(3422)
                {
                    Label = "5-10",
                    ValueLabel = "3422",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(1122)
                {
                    Label = "10-15",
                    ValueLabel = "1122",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(864)
                {
                    Label = "15-20",
                    ValueLabel = "864",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(5678)
                {
                    Label = "20-25",
                    ValueLabel = "5678",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(2311)
                {
                    Label = "25-30",
                    ValueLabel = "2311",
                    Color = SKColor.Parse("#b455b6")
                }
            };

            return new Tuple<Entry[], Entry[]>(incomeEntries, expenseEntries);
        }

        private Tuple<Entry[], Entry[]> GetWeekly()
        {
            //TODO:Get entries from the adapter 

            var incomeEntries = new Entry[]
            {
                new Entry(988)
                {
                    Label = "Mon",
                    ValueLabel = "988",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(344)
                {
                    Label = "Tus",
                    ValueLabel = "344",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(85)
                {
                    Label = "Wed",
                    ValueLabel = "85",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(125)
                {
                    Label = "Thr",
                    ValueLabel = "125",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(743)
                {
                    Label = "Fri",
                    ValueLabel = "743",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(123)
                {
                    Label = "Sat",
                    ValueLabel = "123",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(412)
                {
                    Label = "Sun",
                    ValueLabel = "412",
                    Color = SKColor.Parse("#3498db")
                }
            };
            var expensesEntries = new Entry[]
            {
                new Entry(213)
                {
                    Label = "Mon",
                    ValueLabel = "213",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(932)
                {
                    Label = "Tus",
                    ValueLabel = "932",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(13)
                {
                    Label = "Wed",
                    ValueLabel = "13",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(94)
                {
                    Label = "Thr",
                    ValueLabel = "94",
                    Color = SKColor.Parse("#3498db")
                },
                new Entry(851)
                {
                    Label = "Fri",
                    ValueLabel = "851",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(42)
                {
                    Label = "Sat",
                    ValueLabel = "42",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(142)
                {
                    Label = "Sun",
                    ValueLabel = "142",
                    Color = SKColor.Parse("#3498db")
                }
            };

            return new Tuple<Entry[], Entry[]>(incomeEntries, expensesEntries);
        }

        private Tuple<Entry[], Entry[]> GetDaily()
        {
            //TODO:Get entries from the adapter FOR EACH HH/MM THAT INCOME IS RECORDED

            var incomeEntries = new Entry[]
            { 
                new Entry(12)
                {
                    Label = "03:32am",
                    ValueLabel = "112",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(54)
                {
                    Label = "09:03am",
                    ValueLabel = "54",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(87)
                {
                    Label = "04:24pm",
                    ValueLabel = "87",
                    Color = SKColor.Parse("#2c3e50")
                }
            };
            var expensesEntries = new Entry[]
            {
                new Entry(5)
                {
                    Label = "03:32am",
                    ValueLabel = "5",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(2)
                {
                    Label = "09:03am",
                    ValueLabel = "2",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(8)
                {
                    Label = "04:24pm",
                    ValueLabel = "8",
                    Color = SKColor.Parse("#2c3e50")
                }
            };

            return new Tuple<Entry[], Entry[]>(incomeEntries, expensesEntries);
        }
    }
}
