/* JEsMS (Romeo) -  A Java soccer management game
* Copyright (C) 2004  Angelo Scotto (scotto_a@hotmail.com)
* 
* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; either version 2
* of the License, or (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

/*
* Player.java
*
* Created on 24 dicembre 2003, 19.38
*/
using System;

////UPGRADE_TODO: The type 'com.sun.org.apache.xpath.internal_Renamed.NodeSet' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
//using NodeSet = com.sun.org.apache.xpath.internal_Renamed.NodeSet;
////UPGRADE_TODO: The package 'javax.xml.xpath' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
//using javax.xml.xpath;

namespace CSEsMS.Engine
{
    /// <summary>
    /// HZ: esta será la entidad Player que hay que reemplazar /modificar por la que graba en la BD y usa NHibernate? 
    /// Creo que si.
    /// </summary>
    public class Player
    {
        #region Campos
        /*----- Personal Info -----*/
        protected internal string name;
        protected internal string nationality;
        protected internal int age;

        /*----- Skills -----*/
        protected internal int keeping;
        protected internal int tackling;
        protected internal int passing;
        protected internal int shooting;
        protected internal int aggression;

        /*----- Ability -----*/
        protected internal int keepingAbility;
        protected internal int tacklingAbility;
        protected internal int passingAbility;
        protected internal int shootingAbility;

        /*----- Statistics (Current Season) -----*/
        protected internal int games;
        protected internal int saves;
        protected internal int tackles;
        protected internal int keyPasses;
        protected internal int shots;
        protected internal int goals;
        protected internal int assists;
        protected internal int dps;

        // This field contains the player's fitness (an integer between 0 and 100)
        protected internal int fitness;
        protected internal int stamina;

        protected internal PreferredSide preferredside;

        /*----- Player Not Available -----*/
        protected internal int injury;
        protected internal int suspension;
        #endregion

        #region Propiedades
        virtual public int Fitness
        {
            get
            {
                return fitness;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a;
                //if (((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("fitness") != null)
                //{
                //    a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("fitness");
                //    a.setTextContent(System.Convert.ToString(value));
                //}
                //else
                //{
                //    a = playerNode.OwnerDocument.CreateAttribute("fitness");
                //    a.setTextContent(System.Convert.ToString(value));
                //    playerNode.AppendChild(a);
                //}
                this.fitness = value;
            }
			
        }
        virtual public string Name
        {
            /*----- Personal Info Beans -----*/
			
            get
            {
                return name;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("name");
                //a.Value = value;
				
                this.name = value;
            }
			
        }
        virtual public string Nationality
        {
            get
            {
                return nationality;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("nationality");
                //a.Value = value;
                this.nationality = value;
            }
			
        }
        virtual public int Age
        {
            get
            {
                return age;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("age");
                //a.Value = System.Convert.ToString(value);
                this.age = value;
            }
			
        }
        virtual public int Keeping
        {
            /*----- Skills Beans-----*/
			
            get
            {
                return keeping;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("shootStopping");
                //a.Value = System.Convert.ToString(value);
                this.keeping = value;
            }
			
        }
        virtual public PreferredSide PreferredSide
        {
            get
            {
                return this.preferredside;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a;
                //if (((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("preferredSide") != null)
                //{
                //    a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("preferredSide");
                //    a.setTextContent(value.ToString());
                //}
                //else
                //{
                //    a = playerNode.OwnerDocument.CreateAttribute("preferredSide");
                //    a.setTextContent(value.ToString());
                //    playerNode.AppendChild(a);
                //}
                this.preferredside = value;
            }
			
        }
        virtual public int Tackling
        {
            get
            {
                return tackling;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("tackling");
                //a.Value = System.Convert.ToString(value);
                this.tackling = value;
            }
			
        }
        virtual public int Passing
        {
            get
            {
                return passing;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("passing");
                //a.Value = System.Convert.ToString(value);
                this.passing = value;
            }
			
        }
        virtual public int Shooting
        {
            get
            {
                return shooting;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("shooting");
                //a.Value = System.Convert.ToString(value);
                this.shooting = value;
            }
			
        }
        virtual public int Games
        {
            /*----- Statistics Beans (Current Season) -----*/
			
            get
            {
                return games;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("games");
                //a.Value = System.Convert.ToString(value);
                this.games = value;
            }
			
        }
        virtual public int Dps
        {
            get
            {
                return dps;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("dps");
                //a.Value = System.Convert.ToString(value);
                this.dps = value;
            }
			
        }
        virtual public int Suspension
        {
            get
            {
                return suspension;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("suspension");
                //a.Value = System.Convert.ToString(value);
                this.suspension = value;
            }
			
        }
        virtual public int Injury
        {
            /*----- Player Not Available Beans -----*/
			
            get
            {
                return injury;
            }
			
            set
            {
                // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
                //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("injury");
                //a.Value = System.Convert.ToString(value);
                this.injury = value;
            }

        }
        #endregion

        #region Estos get y set se pueden convertir.
        //Estos get y set se pueden convertir en propiedades para optimizar la escritura del codigo pero al funcionamiento es lo mismo. Habria que buscar en internet en que casos conviene usar propiedades y en que casos metodos
        public virtual int getAggression()
        {
            return aggression;
        }
        public virtual void setAggression(int aggression)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute)((System.Xml.XmlAttributeCollection)playerNode.Attributes).GetNamedItem("aggression");
            //a.Value = System.Convert.ToString(aggression);
            this.aggression = aggression;
        }

        /*----- Ability Beans -----*/
        public virtual int getKeepingAbility()
        {
            return keepingAbility;
        }
        public virtual int getTacklingAbility()
        {
            return tacklingAbility;
        }
        public virtual int getPassingAbility()
        {
            return passingAbility;
        }
        public virtual int getShootingAbility()
        {
            return shootingAbility;
        }
        public virtual int getSaves()
        {
            return saves;
        }
        public virtual int getTackles()
        {
            return tackles;
        }
        public virtual int getKeyPasses()
        {
            return keyPasses;
        }
        public virtual int getShots()
        {
            return shots;
        }
        public virtual int getGoals()
        {
            return goals;
        }
        public virtual int getAssists()
        {
            return assists;
        }

        public virtual void setShots(int shots)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("shots");
            //a.Value = System.Convert.ToString(shots);
            this.shots = shots;
        }
        public virtual void setAssists(int assists)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("assists");
            //a.Value = System.Convert.ToString(assists);
            this.assists = assists;
        }
        public virtual void setKeyPasses(int keyPasses)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("assists");
            //a.Value = System.Convert.ToString(assists);
            this.keyPasses = keyPasses;
        }
        public virtual void setTackles(int tackles)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("keyTackles");
            //a.Value = System.Convert.ToString(tackles);
            this.tackles = tackles;
        }
        public virtual void setSaves(int saves)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("saves");
            //a.Value = System.Convert.ToString(saves);
            this.saves = saves;
        }
        public virtual void setGoals(int goals)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("goals");
            //a.Value = System.Convert.ToString(goals);
            this.goals = goals;
        }

        protected internal virtual void setKeepingAbility(int keepingAbility)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("shootStoppingAbility");
            //a.Value = System.Convert.ToString(keepingAbility);
            this.keepingAbility = keepingAbility;
        }

        protected internal virtual void setTacklingAbility(int tacklingAbility)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("tacklingAbility");
            //a.Value = System.Convert.ToString(tacklingAbility);
            this.tacklingAbility = tacklingAbility;
        }

        protected internal virtual void setPassingAbility(int passingAbility)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("passingAbility");
            //a.Value = System.Convert.ToString(passingAbility);
            this.passingAbility = passingAbility;
        }

        protected internal virtual void setShootingAbility(int shootingAbility)
        {
            // TODO: HZ - ver si esta parte que graba XML hay que hacerlo cuando lo reemplace con una DAL o si se hace de otra manera. Al parecer cada vez que setea un valor graba el dato, hay que ver la logica de como lo implementa. Todo esto lo hace por cada jugador que tiene en memoria (playerNode)
            //System.Xml.XmlAttribute a = (System.Xml.XmlAttribute) ((System.Xml.XmlAttributeCollection) playerNode.Attributes).GetNamedItem("shootingAbility");
            //a.Value = System.Convert.ToString(shootingAbility);
            this.shootingAbility = shootingAbility;
        }

        public virtual bool likeSide(PreferredSide side)
        {
            return this.preferredside.isCompatible(side);
        }
        #endregion

        #region Constructores
        public Player(System.Xml.XmlElement playerNode)
        {
            throw new NotImplementedException("Error en Engine.Player.Player(System.Xml.XmlElement playerNode) -  HZ: este metodo carga los campos a partir de un 'XmlElement playerNode', habria que reemplazarlo por el DAL. Prestar atencion a la parte final cuando no tiene ciertas caracteristicas.");

            //this.playerNode = playerNode;
            //System.Xml.XmlNamedNodeMap attr = (System.Xml.XmlAttributeCollection) playerNode.Attributes;
            //this.name = attr.GetNamedItem("name").getTextContent();
            //this.nationality = attr.GetNamedItem("nationality").getTextContent();
            //this.age = Integer.parseInt(attr.GetNamedItem("age").getTextContent());
            //this.aggression = Integer.parseInt(attr.GetNamedItem("aggression").getTextContent());
            //this.assists = Integer.parseInt(attr.GetNamedItem("assists").getTextContent());
            //this.dps = Integer.parseInt(attr.GetNamedItem("dps").getTextContent());
            //this.games = Integer.parseInt(attr.GetNamedItem("games").getTextContent());
            //this.goals = Integer.parseInt(attr.GetNamedItem("goals").getTextContent());
            //this.injury = Integer.parseInt(attr.GetNamedItem("injury").getTextContent());
            //this.keyPasses = Integer.parseInt(attr.GetNamedItem("keyPasses").getTextContent());
            //this.tackles = Integer.parseInt(attr.GetNamedItem("keyTackles").getTextContent());
            //this.passing = Integer.parseInt(attr.GetNamedItem("passing").getTextContent());
            //this.passingAbility = Integer.parseInt(attr.GetNamedItem("passingAbility").getTextContent());
            //this.saves = Integer.parseInt(attr.GetNamedItem("saves").getTextContent());
            //this.keeping = Integer.parseInt(attr.GetNamedItem("shootStopping").getTextContent());
            //this.keepingAbility = Integer.parseInt(attr.GetNamedItem("shootStoppingAbility").getTextContent());
            //this.shooting = Integer.parseInt(attr.GetNamedItem("shooting").getTextContent());
            //this.shootingAbility = Integer.parseInt(attr.GetNamedItem("shootingAbility").getTextContent());
            //this.shots = Integer.parseInt(attr.GetNamedItem("shots").getTextContent());
            //this.suspension = Integer.parseInt(attr.GetNamedItem("suspension").getTextContent());
            //this.tackling = Integer.parseInt(attr.GetNamedItem("tackling").getTextContent());
            //this.tacklingAbility = Integer.parseInt(attr.GetNamedItem("tacklingAbility").getTextContent());

            //if (attr.GetNamedItem("preferredSide") != null && attr.GetNamedItem("fitness") != null && attr.GetNamedItem("stamina") != null)
            //{
            //    this.preferredside = new PreferredSide(attr.GetNamedItem("preferredSide").getTextContent());
            //    this.fitness = Integer.parseInt(attr.GetNamedItem("fitness").getTextContent());
            //    this.stamina = Integer.parseInt(attr.GetNamedItem("stamina").getTextContent());
            //}
            //else
            //{
            //    this.preferredside = new PreferredSide("RLC");
            //    this.fitness = 100;
            //    this.stamina = 50;
            //}
        }

        /// <summary>Horrific constructor of Player object: it is called directly inside the XML parser
        /// of roster file 
        /// </summary>
        public Player(string name, string nationality, int age, int keeping, int tackling, int passing, int shooting, int aggression, int keepingAbility, int tacklingAbility, int passingAbility, int shootingAbility, int games, int saves, int tackles, int keyPasses, int shots, int goals, int assists, int dps, int injury, int suspension)
        {
            this.name = name;
            this.nationality = nationality;
            this.age = age;
            this.keeping = keeping;
            this.tackling = tackling;
            this.passing = passing;
            this.shooting = shooting;
            this.aggression = aggression;
            this.keepingAbility = keepingAbility;
            this.tacklingAbility = tacklingAbility;
            this.passingAbility = passingAbility;
            this.shootingAbility = shootingAbility;
            this.games = games;
            this.saves = saves;
            this.tackles = tackles;
            this.keyPasses = keyPasses;
            this.shots = shots;
            this.goals = goals;
            this.assists = assists;
            this.dps = dps;
            this.injury = injury;
            this.suspension = suspension;
            // ESMS 2.7
            this.preferredside = new PreferredSide("RLC");
            this.fitness = 100;
            this.stamina = 50;

            throw new NotImplementedException("Error en Engine.Player.Player(...) -  HZ: este metodo carga los campos a partir de los parametros, finalmente llama a createNode() para crear un XMLNode con estos datos, seria como agregar el registro en la BD y luego tener el objeto para usarlo en sus manipulaciones. Ver de reemplazarlo por el DAL.");
            //this.playerNode = createNode();
        }

        /// <summary>Horrific constructor of Player object: it is called directly inside the XML parser
        /// of roster file 
        /// </summary>
        public Player(string name, string nationality, int age, int keeping, int tackling, int passing, int shooting, int aggression, int keepingAbility, int tacklingAbility, int passingAbility, int shootingAbility, int games, int saves, int tackles, int keyPasses, int shots, int goals, int assists, int dps, int injury, int suspension, int fitness, int stamina, PreferredSide preferredside)
        {

            this.name = name;
            this.nationality = nationality;
            this.age = age;
            this.keeping = keeping;
            this.tackling = tackling;
            this.passing = passing;
            this.shooting = shooting;
            this.aggression = aggression;
            this.keepingAbility = keepingAbility;
            this.tacklingAbility = tacklingAbility;
            this.passingAbility = passingAbility;
            this.shootingAbility = shootingAbility;
            this.games = games;
            this.saves = saves;
            this.tackles = tackles;
            this.keyPasses = keyPasses;
            this.shots = shots;
            this.goals = goals;
            this.assists = assists;
            this.dps = dps;
            this.injury = injury;
            this.suspension = suspension;
            // ESMS 2.7
            this.preferredside = preferredside;
            this.fitness = fitness;
            this.stamina = stamina;

            throw new NotImplementedException("Error en Engine.Player.Player(...) -  HZ: este metodo carga los campos a partir de los parametros, finalmente llama a createNode() para crear un XMLNode con estos datos, sería como agregar un registro a la BD y luego tener el objeto para usarlo en sus manipulaciones. Ver de reemplazarlo por el DAL.");
            //this.playerNode = createNode();
        }

        public Player()
        {
        }
        #endregion

        #region Metodos que modifican caracteristicas de los jugadores
        public virtual void increaseAge()
        {
            this.Age = ++age;
        }
		
        // TODO: HZ - revisar los metodos que aumentos caracteristicas luego de los partidos
        /*------ Methods used by the updater program and NOT by the ESMS ------*/
        /// <summary>Method used to increase abilities after a match.
        /// It should take care of overflow in abilities and increase of skills as well.
        /// Used after match by updtr program.
        /// </summary>
        public virtual void  increaseAbilities(int keepingAbility, int tacklingAbility, int passingAbility, int shootingAbility)
        {
            this.setKeepingAbility(this.keepingAbility + keepingAbility);
            if (this.keepingAbility >= 1000)
            {
                this.Keeping = ++this.keeping;
                this.setKeepingAbility(this.keepingAbility - 700);
            }
            else if (this.keepingAbility <= 0)
            {
                if (this.keeping > 0)
                    this.Keeping = --this.keeping;
                this.setKeepingAbility(this.keepingAbility + 700);
            }
			
            this.setTacklingAbility(this.tacklingAbility + tacklingAbility);
            if (this.tacklingAbility >= 1000)
            {
                this.Tackling = ++this.tackling;
                this.setTacklingAbility(this.tacklingAbility - 700);
            }
            else if (this.tacklingAbility <= 0)
            {
                if (this.tackling > 0)
                    this.Tackling = --this.tackling;
                this.setTacklingAbility(this.tacklingAbility + 700);
            }
			
            this.setPassingAbility(this.passingAbility + passingAbility);
            if (this.passingAbility >= 1000)
            {
                this.Passing = ++this.passing;
                this.setPassingAbility(this.passingAbility - 700);
            }
            else if (this.passingAbility <= 0)
            {
                if (this.passing > 0)
                    this.Passing = --this.passing;
                this.setPassingAbility(this.passingAbility + 700);
            }
			
            this.setShootingAbility(this.shootingAbility + shootingAbility);
            if (this.shootingAbility >= 1000)
            {
                this.Shooting = ++this.shooting;
                this.setShootingAbility(this.shootingAbility - 700);
            }
            else if (this.shootingAbility <= 0)
            {
                if (this.shooting > 0)
                    this.Shooting = --this.shooting;
                this.setShootingAbility(this.shootingAbility + 700);
            }
        }
		
        public virtual void  increaseStats(int saves, int tackles, int keyPasses, int shots, int goals, int assists, int dps)
        {
            this.Games = ++games;
            this.setSaves(this.saves + saves);
            this.setTackles(this.tackles + tackles);
            this.setKeyPasses(this.keyPasses + keyPasses);
            this.setShots(this.shots + shots);
            this.setGoals(this.goals + goals);
            this.setAssists(this.assists + assists);

            int multiplier = Config.getConfig().SuspensionMargin;
            int before = this.dps / multiplier;
			
            this.Dps = this.dps + dps;
			
            int after = this.dps / multiplier;
            if (after > before)
                this.Suspension = after;
        }
		
        public virtual void  decreaseSuspension()
        {
            if (this.suspension > 0)
            {
                //this.suspension--;
                this.Suspension = --this.suspension;
            }
        }
		
        public virtual void  decreaseInjury()
        {
            if (this.injury > 0)
            {
                //this.injury--;
                this.Injury = --this.injury;
            }
        }

        /// <summary>Contrary to what the name suggests this methods is used when a player is
        /// suspended OR injured during a match.
        /// It simply set the corresponding variable to the number of weeks that the player
        /// must be out.
        /// </summary>
        /// <param name="injured">If it's true the player is injured so the field injury must be increased of
        /// <CODE>weeks</CODE> otherwise the player is suspended so the field suspension
        /// must be increased of <CODE>weeks</CODE>
        /// </param>
        /// <param name="weeks">An integer representing the number of weeks that the player must stay out
        /// (usually chosen by the updater program)
        /// </param>
        public virtual void Suspended(bool injured, int weeks)
        {
            if (injured)
            {
                //this.injury = weeks;
                this.Injury = weeks;
            }
            else
                this.Suspension = weeks;
            //this.suspension = weeks;
        }

        /// <summary>Method used after a match to decrease the weeks of suspension (caused by BOTH
        /// injury or suspension).
        /// If the player is not suspended or injured the method exits without touching
        /// player fields.
        /// </summary>
        /// <returns> This method returns a boolean which is true if the player is available for the
        /// next match, false otherwise.
        /// </returns>
        public bool decreaseSuspended()
        {
            if (this.injury > 0) this.injury--;
            else if (this.suspension > 0) this.suspension--;
            return (this.suspension == 0 && this.injury == 0);
        }
        #endregion

        #region Metodos auxiliares para generar jugadores de prueba
        public static Player GenerateKeeper(float[] averageValue, System.Random rnd)
        {
            System.Random r = rnd;
            float aggr = (float)r.NextDouble();
            aggr = aggr * averageValue[0] * 2;
            float keeping = (float)r.NextDouble();
            keeping = keeping * averageValue[1] * 2;
            float tackling = (float)r.NextDouble();
            tackling = tackling * averageValue[2] * 2;
            float passing = (float)r.NextDouble();
            passing = passing * averageValue[2] * 2;
            float shooting = (float)r.NextDouble();
            shooting = shooting * averageValue[2] * 2;
            return new Player("Unnamed", "ITA", 21, (int)keeping, (int)tackling, (int)passing, (int)shooting, (int)aggr, 300, 300, 300, 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public static Player GenerateDefender(float[] averageValue, System.Random rnd)
        {
            System.Random r = rnd;
            float aggr = (float)r.NextDouble();
            aggr = aggr * averageValue[0] * 2;
            float keeping = (float)r.NextDouble();
            keeping = keeping * averageValue[2] * 2;
            float tackling = (float)r.NextDouble();
            tackling = tackling * averageValue[1] * 2;
            float passing = (float)r.NextDouble();
            passing = passing * averageValue[2] * 2;
            float shooting = (float)r.NextDouble();
            shooting = shooting * averageValue[2] * 2;
            return new Player("Unnamed", "ITA", 21, (int)keeping, (int)tackling, (int)passing, (int)shooting, (int)aggr, 300, 300, 300, 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        public static Player GenerateMidfielder(float[] averageValue, System.Random rnd)
        {
            System.Random r = rnd;
            float aggr = (float)r.NextDouble();
            aggr = aggr * averageValue[0] * 2;
            float keeping = (float)r.NextDouble();
            keeping = keeping * averageValue[2] * 2;
            float tackling = (float)r.NextDouble();
            tackling = tackling * averageValue[2] * 2;
            float passing = (float)r.NextDouble();
            passing = passing * averageValue[1] * 2;
            float shooting = (float)r.NextDouble();
            shooting = shooting * averageValue[2] * 2;
            return new Player("Unnamed", "ITA", 21, (int)keeping, (int)tackling, (int)passing, (int)shooting, (int)aggr, 300, 300, 300, 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public static Player GenerateForwarder(float[] averageValue, System.Random rnd)
        {
            System.Random r = rnd;
            float aggr = (float)r.NextDouble();
            aggr = aggr * averageValue[0] * 2;
            float keeping = (float)r.NextDouble();
            keeping = keeping * averageValue[2] * 2;
            float tackling = (float)r.NextDouble();
            tackling = tackling * averageValue[2] * 2;
            float passing = (float)r.NextDouble();
            passing = passing * averageValue[2] * 2;
            float shooting = (float)r.NextDouble();
            shooting = shooting * averageValue[1] * 2;
            return new Player("Unnamed", "ITA", 21, (int)keeping, (int)tackling, (int)passing, (int)shooting, (int)aggr, 300, 300, 300, 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        #endregion
        
        #region Metodos de objetos
        public override bool Equals(System.Object obj)
        {
            if (obj.GetType() != typeof(Player))
                return false;
            Player p = (Player)obj;
            return p.Name.Equals(this.Name);
        }
        #endregion

        #region Logica comentada
        //virtual public System.Xml.XmlElement Node
        //{
        //    get
        //    {
        //        return playerNode;
        //    }

        //}

        //private System.Xml.XmlElement playerNode;
        
        //#region Metodos que graban datos (DAL para el XML)
        //private System.Xml.XmlElement createNode()
        //{
        //    throw new NotImplementedException("Error en Engine.Player.createNode - HZ: este metodo habria que reemplazarlo por el metodo que hace el INSERT en la BD.");

        //    //try
        //    //{
        //    //    //UPGRADE_TODO: Class 'javax.xml.parsers.DocumentBuilder' was converted to 'System.Xml.XmlDocument' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilder'"
        //    //    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        //    //    System.Xml.XmlElement answer = (System.Xml.XmlElement) doc.CreateElement("Player");
        //    //    System.Xml.XmlAttribute a = doc.CreateAttribute("name");
        //    //    a.Value = this.name;
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("nationality");
        //    //    a.Value = this.nationality;
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("age");
        //    //    a.Value = System.Convert.ToString(this.age);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("shootStopping");
        //    //    a.Value = System.Convert.ToString(this.keeping);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("tackling");
        //    //    a.Value = System.Convert.ToString(this.tackling);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("passing");
        //    //    a.Value = System.Convert.ToString(this.passing);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("shooting");
        //    //    a.Value = System.Convert.ToString(this.shooting);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("aggression");
        //    //    a.Value = System.Convert.ToString(this.aggression);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("shootStoppingAbility");
        //    //    a.Value = System.Convert.ToString(this.keepingAbility);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("tacklingAbility");
        //    //    a.Value = System.Convert.ToString(this.tacklingAbility);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("passingAbility");
        //    //    a.Value = System.Convert.ToString(this.passingAbility);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("shootingAbility");
        //    //    a.Value = System.Convert.ToString(this.shootingAbility);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("games");
        //    //    a.Value = System.Convert.ToString(this.games);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("saves");
        //    //    a.Value = System.Convert.ToString(this.saves);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("keyTackles");
        //    //    a.Value = System.Convert.ToString(this.tackles);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("keyPasses");
        //    //    a.Value = System.Convert.ToString(this.keyPasses);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("shots");
        //    //    a.Value = System.Convert.ToString(this.shots);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("goals");
        //    //    a.Value = System.Convert.ToString(this.goals);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("assists");
        //    //    a.Value = System.Convert.ToString(this.assists);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("dps");
        //    //    a.Value = System.Convert.ToString(this.dps);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("injury");
        //    //    a.Value = System.Convert.ToString(this.injury);
        //    //    answer.SetAttributeNode(a);
        //    //    a = doc.CreateAttribute("suspension");
        //    //    a.Value = System.Convert.ToString(this.suspension);
        //    //    answer.SetAttributeNode(a);
        //    //    return answer;
        //    //}
        //    ////UPGRADE_TODO: Class 'org.w3c.dom.DOMException' was converted to 'System.Exceptiont' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
        //    //catch (System.Exception ex)
        //    //{
        //    //    SupportClass.WriteStackTrace(ex, Console.Error);
        //    //    return null;
        //    //}
        //    ////UPGRADE_ISSUE: Class 'javax.xml.parsers.ParserConfigurationException' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersParserConfigurationException'"
        //    //catch (ParserConfigurationException ex)
        //    //{
        //    //    SupportClass.WriteStackTrace(ex, Console.Error);
        //    //    return null;
        //    //}
        //}

        ///// <summary>This method write the XML text representing this player instance on a java.io.Writer
        ///// object.
        ///// This method doesn't write an XML file but just the chunk of XML needed to build
        ///// the Player entity (see Roster XML schema), it should therefore be called inside
        ///// the method creating or updating the roster XML file.
        ///// </summary>
        ////UPGRADE_ISSUE: Class hierarchy differences between 'java.io.Writer' and 'System.IO.StreamWriter' may cause compilation errors. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1186'"
        //public virtual void  WriteRoster(System.IO.StreamWriter out_Renamed)
        //{
        //    throw new NotImplementedException("Error en Engine.Player.WriteRoster(System.IO.StreamWriter out_Renamed) -  HZ: este metodo escribe los campos en el XML (create o update), habria que reemplazarlo por el DAL.");

        //    ////UPGRADE_TODO: Class 'javax.xml.transform.dom.DOMSource' was converted to 'DomSourceSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformdomDOMSource'"
        //    //DomSourceSupport source = new DomSourceSupport(playerNode);
        //    //GenericResultSupport result = new GenericResultSupport(out_Renamed);

        //    ////UPGRADE_TODO: Method 'javax.xml.transform.TransformerFactory.newTransformer' was converted to 'SupportClass.TransformerSupport.NewTransform' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformTransformerFactorynewTransformer'"
        //    //TransformerSupport transformer = TransformerSupport.NewTransform(TransformerSupport.NewInstance());

        //    //transformer.DoTransform(source, result);

        //    //out_Renamed.Flush();
        //}
        //#endregion
        #endregion
    }
}