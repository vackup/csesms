using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSEsMS.Domain;
using CSEsMS.Domain.Entities;
using CSEsMS.Domain.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CSEsMS.TestDomainCmdUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Comenzando el proceso.");

                var sessionFactory = SessionFactory.CreateSessionFactoryBuildSchema();
                //var sessionFactory = SessionFactory.CreateSessionFactory();

                //// create our NHibernate session factory
                //var sessionFactory = SessionFactory.CreateSessionFactory();

                using (var session = sessionFactory.OpenSession())
                {
                    // populate the database
                    using (var transaction = session.BeginTransaction())
                    {
                        // create a couple of Stores each with some Products and Employees
                        var oLigaClausura2010 = new League {Name = "Clausura 2010"};

                        oLigaClausura2010.AbGoal = 0;
                        oLigaClausura2010.AbAssist = 0;
                        oLigaClausura2010.AbVictoryRandom = 0;
                        oLigaClausura2010.AbDefeatRandom = 0;
                        oLigaClausura2010.AbCleanSheet = 0;
                        oLigaClausura2010.AbKeyTackling = 0;
                        oLigaClausura2010.AbKeyPasses = 0;
                        oLigaClausura2010.AbShotsOn = 0;
                        oLigaClausura2010.AbShotsOff = 0;
                        oLigaClausura2010.AbSaves = 0;
                        oLigaClausura2010.AbConceded = 0;
                        oLigaClausura2010.AbYellow = 0;
                        oLigaClausura2010.AbRed = 0;
                        oLigaClausura2010.MaxInjuryLength = 9;
                        oLigaClausura2010.CupMatch = 0;
                        oLigaClausura2010.WinPoint = 3;
                        oLigaClausura2010.DrawPoint = 1;
                        oLigaClausura2010.Debug = false;

                        var oEquipoNOB = new Team {AbbrName = "NOB", Name = "Newells"};
                        var oEquipoRC = new Team {AbbrName = "CARC", Name = "Rosario Central"};
                        var oEquipoBoca = new Team {AbbrName = "CABJ", Name = "Boca Juniors"};
                        var oEquipoRiver = new Team {AbbrName = "CARP", Name = "River Plate"};

                        oLigaClausura2010.AddTeam(oEquipoNOB);
                        oLigaClausura2010.AddTeam(oEquipoRC);
                        oLigaClausura2010.AddTeam(oEquipoBoca);
                        oLigaClausura2010.AddTeam(oEquipoRiver);
                        
                        oEquipoNOB.AddPlayer(new Player { Name = "Perata", Age = 30, Nationality = "ARG", ShootStopping = 1, Tackling = 1, Passing = 1, Shooting = 1, Aggression = 1, ShootStoppingAbility = 1, TacklingAbility = 1, PassingAbility = 1, ShootingAbility = 1, Games = 1, Saves = 1, KeyTackles = 1, KeyPasses = 1, Shots = 1, Goals = 1, Assists = 1, Dps = 1, Injury = 1, Suspension = 1 });
                        oEquipoNOB.AddPlayer(new Player { Name = "Schiavi", Age = 30, Nationality = "ARG", ShootStopping = 1, Tackling = 1, Passing = 1, Shooting = 1, Aggression = 1, ShootStoppingAbility = 1, TacklingAbility = 1, PassingAbility = 1, ShootingAbility = 1, Games = 1, Saves = 1, KeyTackles = 1, KeyPasses = 1, Shots = 1, Goals = 1, Assists = 1, Dps = 1, Injury = 1, Suspension = 1 });
                        oEquipoNOB.AddPlayer(new Player { Name = "Boghosian", Age = 30, Nationality = "ARG", ShootStopping = 1, Tackling = 1, Passing = 1, Shooting = 1, Aggression = 1, ShootStoppingAbility = 1, TacklingAbility = 1, PassingAbility = 1, ShootingAbility = 1, Games = 1, Saves = 1, KeyTackles = 1, KeyPasses = 1, Shots = 1, Goals = 1, Assists = 1, Dps = 1, Injury = 1, Suspension = 1 });

                        session.SaveOrUpdate(oLigaClausura2010);

                    //    transaction.Commit();
                    //}

                    //// populate the database
                    //using (var transaction = session.BeginTransaction())
                    //{
                        // create a couple of Stores each with some Products and Employees
                        var TacticN = new Tactic {Name = "N"};
                        var TacticD = new Tactic {Name = "D"};
                        var TacticA = new Tactic {Name = "A"};
                        var TacticC = new Tactic {Name = "C"};
                        var TacticL = new Tactic {Name = "L"};
                        var TacticP = new Tactic {Name = "P"};

                        TacticN.AddTeam(oEquipoNOB);
                        TacticD.AddTeam(oEquipoRC);
                        TacticA.AddTeam(oEquipoBoca);
                        TacticC.AddTeam(oEquipoRiver);
                        //TacticL.AddTeam(oEquipoNOB);
                        //TacticP.AddTeam(oEquipoNOB);

                        TacticN.AddMult(new Mult {Position = "DF", Skill = "TK", Multiplier = 1.0});
                        TacticN.AddMult(new Mult {Position = "DF", Skill = "PS", Multiplier = 0.5});
                        TacticN.AddMult(new Mult {Position = "DF", Skill = "SH", Multiplier = 0.3});
                        TacticN.AddMult(new Mult {Position = "MF", Skill = "TK", Multiplier = 0.3});
                        TacticN.AddMult(new Mult {Position = "MF", Skill = "PS", Multiplier = 1.0});
                        TacticN.AddMult(new Mult {Position = "MF", Skill = "SH", Multiplier = 0.3});
                        TacticN.AddMult(new Mult {Position = "FW", Skill = "TK", Multiplier = 0.3});
                        TacticN.AddMult(new Mult {Position = "FW", Skill = "PS", Multiplier = 0.3});
                        TacticN.AddMult(new Mult {Position = "FW", Skill = "SH", Multiplier = 1.0});

                        TacticD.AddMult(new Mult {Position = "DF", Skill = "TK", Multiplier = 1.25});
                        TacticD.AddMult(new Mult {Position = "DF", Skill = "PS", Multiplier = 0.75});
                        TacticD.AddMult(new Mult {Position = "DF", Skill = "SH", Multiplier = 0.25});
                        TacticD.AddMult(new Mult {Position = "MF", Skill = "TK", Multiplier = 1.0});
                        TacticD.AddMult(new Mult {Position = "MF", Skill = "PS", Multiplier = 0.75});
                        TacticD.AddMult(new Mult {Position = "MF", Skill = "SH", Multiplier = 0.25});
                        TacticD.AddMult(new Mult {Position = "FW", Skill = "TK", Multiplier = 0.5});
                        TacticD.AddMult(new Mult {Position = "FW", Skill = "PS", Multiplier = 0.25});
                        TacticD.AddMult(new Mult {Position = "FW", Skill = "SH", Multiplier = 0.75});

                        TacticA.AddMult(new Mult {Position = "DF", Skill = "TK", Multiplier = 1.0});
                        TacticA.AddMult(new Mult {Position = "DF", Skill = "PS", Multiplier = 0.5});
                        TacticA.AddMult(new Mult {Position = "DF", Skill = "SH", Multiplier = 0.5});
                        TacticA.AddMult(new Mult {Position = "MF", Skill = "TK", Multiplier = 0.0});
                        TacticA.AddMult(new Mult {Position = "MF", Skill = "PS", Multiplier = 1.0});
                        TacticA.AddMult(new Mult {Position = "MF", Skill = "SH", Multiplier = 0.75});
                        TacticA.AddMult(new Mult {Position = "FW", Skill = "TK", Multiplier = 0.0});
                        TacticA.AddMult(new Mult {Position = "FW", Skill = "PS", Multiplier = 0.75});
                        TacticA.AddMult(new Mult {Position = "FW", Skill = "SH", Multiplier = 1.5});

                        TacticC.AddMult(new Mult {Position = "DF", Skill = "TK", Multiplier = 1.0});
                        TacticC.AddMult(new Mult {Position = "DF", Skill = "PS", Multiplier = 0.5});
                        TacticC.AddMult(new Mult {Position = "DF", Skill = "SH", Multiplier = 0.25});
                        TacticC.AddMult(new Mult {Position = "MF", Skill = "TK", Multiplier = 0.5});
                        TacticC.AddMult(new Mult {Position = "MF", Skill = "PS", Multiplier = 1.0});
                        TacticC.AddMult(new Mult {Position = "MF", Skill = "SH", Multiplier = 0.25});
                        TacticC.AddMult(new Mult {Position = "FW", Skill = "TK", Multiplier = 0.5});
                        TacticC.AddMult(new Mult {Position = "FW", Skill = "PS", Multiplier = 0.5});
                        TacticC.AddMult(new Mult {Position = "FW", Skill = "SH", Multiplier = 1.0});

                        TacticL.AddMult(new Mult {Position = "DF", Skill = "TK", Multiplier = 1.0});
                        TacticL.AddMult(new Mult {Position = "DF", Skill = "PS", Multiplier = 0.25});
                        TacticL.AddMult(new Mult {Position = "DF", Skill = "SH", Multiplier = 0.25});
                        TacticL.AddMult(new Mult {Position = "MF", Skill = "TK", Multiplier = 0.5});
                        TacticL.AddMult(new Mult {Position = "MF", Skill = "PS", Multiplier = 1.0});
                        TacticL.AddMult(new Mult {Position = "MF", Skill = "SH", Multiplier = 0.5});
                        TacticL.AddMult(new Mult {Position = "FW", Skill = "TK", Multiplier = 0.25});
                        TacticL.AddMult(new Mult {Position = "FW", Skill = "PS", Multiplier = 0.5});
                        TacticL.AddMult(new Mult {Position = "FW", Skill = "SH", Multiplier = 1.3});

                        TacticP.AddMult(new Mult {Position = "DF", Skill = "TK", Multiplier = 1.0});
                        TacticP.AddMult(new Mult {Position = "DF", Skill = "PS", Multiplier = 0.75});
                        TacticP.AddMult(new Mult {Position = "DF", Skill = "SH", Multiplier = 0.3});
                        TacticP.AddMult(new Mult {Position = "MF", Skill = "TK", Multiplier = 0.25});
                        TacticP.AddMult(new Mult {Position = "MF", Skill = "PS", Multiplier = 1.0});
                        TacticP.AddMult(new Mult {Position = "MF", Skill = "SH", Multiplier = 0.25});
                        TacticP.AddMult(new Mult {Position = "FW", Skill = "TK", Multiplier = 0.25});
                        TacticP.AddMult(new Mult {Position = "FW", Skill = "PS", Multiplier = 0.75});
                        TacticP.AddMult(new Mult {Position = "FW", Skill = "SH", Multiplier = 1.0});

                        TacticD.AddBonus(new Bonus {OppTactic="L", Position="DF", Skill="TK", Multiplier=0.25});

                        TacticA.AddBonus(new Bonus {OppTactic="D", Position="FW", Skill="SH", Multiplier=0.5});

                        TacticC.AddBonus(new Bonus {OppTactic="A", Position="MF", Skill="SH", Multiplier=0.5});
                        TacticC.AddBonus(new Bonus {OppTactic="A", Position="DF", Skill="PS", Multiplier=0.25});
                        TacticC.AddBonus(new Bonus {OppTactic="A", Position="DF", Skill="SH", Multiplier=0.25});
                        TacticC.AddBonus(new Bonus {OppTactic="P", Position="MF", Skill="SH", Multiplier=0.5});
                        TacticC.AddBonus(new Bonus {OppTactic="P", Position="DF", Skill="PS", Multiplier=0.25});
                        TacticC.AddBonus(new Bonus {OppTactic="P", Position="DF", Skill="SH", Multiplier=0.25});

                        TacticL.AddBonus(new Bonus {OppTactic="C", Position="DF", Skill="TK", Multiplier=0.25});
                        TacticL.AddBonus(new Bonus { OppTactic = "C", Position = "DF", Skill = "PS", Multiplier = 0.5 });

                        TacticP.AddBonus(new Bonus {OppTactic="L", Position="MF", Skill="SH", Multiplier=0.5});
                        TacticP.AddBonus(new Bonus { OppTactic = "L", Position = "MF", Skill = "TK", Multiplier = 0.5 });
                        TacticP.AddBonus(new Bonus { OppTactic = "L", Position = "DW", Skill = "SH", Multiplier = 0.25 });

                        session.SaveOrUpdate(TacticN);
                        session.SaveOrUpdate(TacticD);
                        session.SaveOrUpdate(TacticA);
                        session.SaveOrUpdate(TacticC);
                        session.SaveOrUpdate(TacticL);
                        session.SaveOrUpdate(TacticP);

                        transaction.Commit();
                    }
                }

                using (var session = sessionFactory.OpenSession())
                {
                    // retreive all stores and display them
                    using (session.BeginTransaction())
                    {
                        var Ligas = session.CreateCriteria(typeof (League)).List<League>();

                        foreach (var liga in Ligas)
                        {
                            WriteLeagueData(liga);
                        }
                    }
                }

                Console.WriteLine("Fin del proceso.");
            }
            catch (Exception x)
            {

                Console.WriteLine(x.ToString());
            }

            Console.ReadKey();
        }

        private static void WriteLeagueData(League league)
        {
            Console.WriteLine(string.Format("{0} - {1}", league.Id, league.Name));
            Console.WriteLine("  Equipos:");

            foreach (var equipo in league.Teams)
            {
                Console.WriteLine("    " + equipo.Name);
                Console.WriteLine("        Tactica: " + equipo.Tactic.Name);
                Console.WriteLine("        Jugadores: ");

                foreach (var jugador in equipo.Players)
                {
                    Console.WriteLine("    " + jugador.Name);
                }
            }

            Console.WriteLine();
        }
    }
}
