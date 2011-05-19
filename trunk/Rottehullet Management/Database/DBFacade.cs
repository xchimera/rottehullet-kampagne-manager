using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Database
{
	class DBFacade
	{
		DatabaseController databaseController;
		private string sqlconnection;
		//private string sqlconnection = @"Data Source= linux1.tietgen.dk;Initial Catalog=gruppe101.5;User Id=gruppe101.5;Password=9esUdrAc";

		SqlCommand cmd;
		SqlConnection conn;

		public DBFacade(DatabaseController databaseController)
		{
			this.databaseController = databaseController;
			
		}


		//Fylder en tom database med de nødvendige tabeller og
		//stored procedures
		//Lavet af Thorbjørn
		public int FyldDatabase(string datasource,string catalogue,string userid, string password)
		{
			sqlconnection = @"Data Source="+datasource+";Initial Catalog="+catalogue+";User Id="+userid+";Password="+password;
			//cmd = new SqlCommand();
			
			conn = new SqlConnection(sqlconnection);
			try
			{
				conn.Open();
				cmd = conn.CreateCommand();
				cmd.CommandText = "create table Bruger (brugerID bigint primary key identity(1,1),email nvarchar(50) not null,kodeord nvarchar(50) not null,navn nvarchar(50) not null,fødselsdag date not null,tlf bigint not null,nød_tlf bigint not null,allergi nvarchar(100),vegetar bit not null,veganer bit not null,andet nvarchar(500) )";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create table Kampagne (kamID bigint primary key identity(1,1),navn nvarchar(50) not null,beskrivelse nvarchar(500),hjemmeside nvarchar(150),status int not null,topbrugerID bigint not null, CONSTRAINT FK_kampagne_bruger foreign key (topbrugerID) references Bruger (brugerID))";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create table Attribut (attID bigint primary key identity(1,1),kamID bigint not null, navn nvarchar(50) not null,infotype int not null,position int not null,CONSTRAINT FK_attribut_kampagne foreign key (kamID) references Kampagne (kamID))";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create table MultiAttributEntry (entryID bigint primary key identity(1,1),attID bigint not null, værdi nvarchar(50) not null,CONSTRAINT FK_multi_attribut foreign key (attID) references Attribut (attID))";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create table Superbruger (kamID bigint not null, brugerID bigint not null, primary key (kamID, brugerID),CONSTRAINT FK_super_kampagne foreign key (kamID) references Kampagne (kamID),CONSTRAINT FK_super_bruger foreign key (brugerID) references Bruger (brugerID))";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE TABLE Scenarie (scenarieID BIGINT IDENTITY(1,1) PRIMARY KEY,titel NVARCHAR(50) NOT NULL,beskrivelse NVARCHAR(4000) NOT NULL,dato DATETIME NOT NULL,sted NVARCHAR(50) NOT NULL,pris FLOAT,	overnatning INT,overnatningTvungen BIT,spisning BIT,spisningTvungen BIT,andetInfo NVARCHAR(4000) NOT NULL,kampagneID BIGINT,CONSTRAINT FK_Scenarie_Kampagne FOREIGN KEY (kampagneID) REFERENCES Kampagne (kamID));";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE TABLE Karakter (karakterID BIGINT IDENTITY(1,1) PRIMARY KEY,brugerID BIGINT,kampagneID BIGINT,karstatus INT,CONSTRAINT FK_Karakter_Bruger FOREIGN KEY (brugerID) REFERENCES Bruger (brugerID),CONSTRAINT FK_Karakter_Kampagne FOREIGN KEY (kampagneID) REFERENCES Kampagne (kamID));";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE TABLE KarakterAttribut (karakterAttributID BIGINT IDENTITY(1,1) PRIMARY KEY,karakterID BIGINT,attributID BIGINT,værdi NVARCHAR(4000),CONSTRAINT FK_KarakterAttribut_Karakter FOREIGN KEY (karakterID) REFERENCES Karakter (karakterID),CONSTRAINT FK_KarakterAttribut_Attribut FOREIGN KEY (attributID) REFERENCES Attribut (attID));";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE TABLE KarakterMultiAttribut (karakterAttributID BIGINT IDENTITY(1,1) PRIMARY KEY,karakterID BIGINT,attributID BIGINT,multiAttributEntryID BIGINT,CONSTRAINT FK_KarakterMultiAttribut_Karakter FOREIGN KEY (karakterID) REFERENCES Karakter (karakterID),CONSTRAINT FK_KarakterMultiAttribut_Attribut FOREIGN KEY (attributID) REFERENCES Attribut (attID),CONSTRAINT FK_KarakterMultiAttribut_MultiAttributEntry FOREIGN KEY (multiAttributEntryID) REFERENCES MultiAttributEntry (entryID));";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE TABLE Tilmelding(tilmeldingID BIGINT IDENTITY(1,1) PRIMARY KEY,karakterID BIGINT,scenarieID BIGINT,overnatninger INT,spiser BIT,CONSTRAINT FK_KarakterIScenarie_Karakter FOREIGN KEY (karakterID) REFERENCES Karakter (karakterID),CONSTRAINT FK_KarakterIScenarie_Scenarie FOREIGN KEY (scenarieID) REFERENCES Scenarie (scenarieID));";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE BrugerLogin(@email nvarchar(50),@kodeord nvarchar(50))AS SELECT brugerID, navn FROM Bruger WHERE email = @email AND kodeord = @kodeord";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE CheckOmSuperbruger(@brugerID bigint)AS SELECT s.kamID, k.navn FROM Kampagne k, Superbruger s WHERE brugerID = @brugerID AND k.kamID = s.kamID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE CheckOmTopbruger(@brugerID bigint)AS SELECT kamID, navn FROM Kampagne WHERE topbrugerID = @brugerID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE FravælgSuperbruger(@brugerID bigint,@kampagneID bigint)AS BEGIN DELETE FROM Superbruger WHERE @brugerID = brugerID AND @kampagneID = kamID END";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create procedure HentAlleBrugersKarakterer (@brugerID bigint )as select k.*, ka.* from Karakter k LEFT JOIN KarakterAttribut ka ON k.karakterID = ka.karakterID where @brugerID = k.brugerID ORDER BY brugerID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create procedure HentAlleBrugersKaraktererMA (@brugerID bigint )as select kma.attributID as multiattributID, kma.karakterAttributID, kma.karakterID, kma.multiAttributEntryID, (select kampagneID FROM Karakter WHERE Karakter.karakterID = kma.karakterID) AS kampagneID From KarakterMultiAttribut kma where kma.karakterID IN (select k.karakterID FROM Karakter k WHERE @brugerID = k.brugerID) ORDER BY karakterID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentAlleBrugere AS SELECT brugerID, email, kodeord, navn, fødselsdag,tlf,nød_tlf,allergi, veganer,vegetar, andet FROM Bruger WHERE brugerID != 1 ORDER BY brugerID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentAlleKampagner AS SELECT k.*, a.infotype, a.attID, a.navn as attnavn, a.position, m.værdi, m.entryID FROM Kampagne k LEFT JOIN Attribut a ON a.kamID = k.kamID LEFT JOIN MultiAttributEntry m ON a.attID=m.attID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentAlleKampagnensKarakteresMultiAttributter (@kampagneID BIGINT)AS SELECT kma.attributID, kma.karakterAttributID, kma.karakterID, kma.multiAttributEntryID FROM KarakterMultiAttribut kma WHERE kma.karakterID IN (SELECT k.karakterID FROM Karakter k WHERE k.kampagneID = @kampagneID) ORDER BY kma.karakterID ASC;";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentAlleScenarier AS SELECT s.andetInfo, s.beskrivelse, s.dato, s.overnatning, s.overnatningTvungen, s.overnatningTvungen, s.pris, s.scenarieID, s.spisning, s.spisningTvungen, s.sted, s.titel FROM Scenarie s ORDER BY s.kampagneID ASC;";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentAlleTilmeldinger AS SELECT t.karakterID, overnatninger, spiser, scenarieID FROM Karakter k, Tilmelding t WHERE k.karakterID = t.karakterID ORDER BY k.brugerID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentBrugereOgKaraktererTilKampagne(@kamID bigint) AS SELECT k.kampagneID,b.brugerID, b.email, b.navn, b.fødselsdag,b.tlf,b.nød_tlf,b.vegetar,b.veganer,b.allergi, b.andet, k.karakterID, k.karstatus, ka.attributID, ka.karakterAttributID, ka.værdi FROM Bruger b LEFT JOIN Karakter k ON (b.brugerID = k.brugerID AND k.kampagneID = @kamID) LEFT JOIN KarakterAttribut ka ON k.karakterID = ka.karakterID WHERE b.brugerID != 1 ORDER BY b.brugerID, k.karakterID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentBrugereTilKampagne(	@kamID bigint)AS SELECT b.brugerID, b.email, b.navn, b.fødselsdag,b.tlf,b.nød_tlf,b.vegetar,b.veganer,b.allergi, b.andet FROM Bruger b, Kampagne k, Superbruger s WHERE (k.kamID = @kamID AND k.topbrugerID = b.brugerID) OR (s.kamID = @kamID AND s.brugerID = b.brugerID)";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentKampagne (@kamID bigint ) AS SELECT kamID, navn, beskrivelse, hjemmeside, topbrugerID, [status] FROM Kampagne Where kamID = @kamID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentKampagneAttributter(@kamID bigint) AS SELECT a.attID, a.navn, a.infotype, a.position, m.entryID, m.værdi FROM Attribut a LEFT JOIN MultiAttributEntry m ON a.attID=m.attID WHERE a.kamID = @kamID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentKampagnerHvorBrugerenHarRettigheder(@brugerID bigint)AS SELECT k.kamID, k.navn, k.hjemmeside, k.beskrivelse, k.topbrugerID, k.status FROM Kampagne k WHERE k.topbrugerID = @brugerID OR kamID IN (SELECT s.kamID FROM Superbruger s WHERE s.brugerID = @brugerID);";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentScenarierTilKampagne (@kampagneID BIGINT)AS SELECT s.andetInfo, s.beskrivelse, s.dato, s.overnatning, s.overnatningTvungen, s.overnatningTvungen, s.pris, s.scenarieID, s.spisning, s.spisningTvungen, s.sted, s.titel FROM Scenarie s WHERE kampagneID = @kampagneID;";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentSuperbrugerTilKampagne (@kamID bigint)AS BEGIN SELECT b.brugerID FROM Superbruger b WHERE @kamID = b.kamID END";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE HentTilmeldingerTilBruger(@brugerID BIGINT)AS SELECT karakterID, overnatninger, spiser, scenarieID FROM Tilmelding WHERE karakterID IN (SELECT karakterID FROM Karakter WHERE brugerID = @brugerID)";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create procedure KlientLogin (@email nvarchar(50),@kodeord nvarchar(50) )as select navn, fødselsdag, tlf, nød_tlf, allergi, vegetar, veganer, andet, brugerID from Bruger where email = @email and kodeord = @kodeord";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpdaterKarakterStatus(@karakterID bigint,@status int)AS UPDATE Karakter SET karstatus = @status WHERE karakterID = @karakterID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretAttribut(@kamID bigint, @navn nvarchar(50), @infotype int, @position int, @id bigint OUTPUT)AS INSERT INTO Attribut VALUES(@kamID,@navn,@infotype,@position) SET @id=SCOPE_IDENTITY()";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "create procedure OpretBruger(@email nvarchar(50),@kodeord nvarchar(50),@navn nvarchar(50),@fødselsdag date,@tlf bigint,@nød_tlf bigint,@allergi nvarchar(100),@vegetar bit,@veganer bit,@andet nvarchar(500),@brugerID bigint output )as insert into Bruger (email, kodeord, navn, fødselsdag, tlf, nød_tlf, allergi, vegetar, veganer, andet) values (@email, @kodeord, @navn, @fødselsdag, @tlf, @nød_tlf,@allergi, @vegetar, @veganer, @andet) set @brugerID=SCOPE_IDENTITY()";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretKampagne ( @navn nvarchar(50), @topbrugerID bigint, @id bigint OUTPUT, @status int )AS INSERT INTO Kampagne VALUES(@navn, '', '', @status, @topbrugerID) SET @id=SCOPE_IDENTITY()";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretKarakter (@kampagneID BIGINT,@brugerID BIGINT,	@kamstatus INT,	@karakterID BIGINT OUTPUT)AS INSERT INTO Karakter VALUES (@brugerID,@kampagneID,@kamstatus) SET @karakterID = SCOPE_IDENTITY();";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretKarakterAttribut (@karakterID BIGINT,@attributID BIGINT,@værdi nvarchar(4000),	@karakterAttributID BIGINT OUTPUT)AS INSERT INTO KarakterAttribut VALUES (@karakterID, @attributID, @værdi) SET @karakterAttributID = SCOPE_IDENTITY();";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretKarakterMultiAttribut (@karakterID BIGINT,@attributID BIGINT,@multiAttributEntryID BIGINT,@karakterAttributID BIGINT OUTPUT)AS INSERT INTO KarakterMultiAttribut VALUES (@karakterID, @attributID, @multiAttributEntryID) SET @karakterAttributID = SCOPE_IDENTITY();";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretMultiAttributEntry(@attID bigint, @værdi nvarchar(50), @id bigint OUTPUT)AS INSERT INTO MultiAttributEntry VALUES(@attID,@værdi) SET @id=SCOPE_IDENTITY()";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretScenarie (@titel NVARCHAR(50),	@beskrivelse NVARCHAR(4000),@dato DATETIME,@sted NVARCHAR(50),@pris DECIMAL(7,2),@overnatning INT,@overnatningTvungen BIT,@spisning BIT,@spisningTvungen BIT,@andetInfo NVARCHAR(4000),@kampagneID BIGINT,@scenarieID BIGINT OUTPUT)AS INSERT INTO Scenarie VALUES (@titel, @beskrivelse, @dato, @sted, @pris, @overnatning, @overnatningTvungen, @spisning, @spisningTvungen, @andetInfo, @kampagneID) SET @scenarieID = SCOPE_IDENTITY();";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE OpretSuperbruger(@kamID bigint,@brugerID bigint)AS INSERT INTO Superbruger VALUES(@kamID,@brugerID)";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetAdminKodeord(@adminkode nvarchar(50))AS UPDATE Bruger SET kodeord = @adminkode WHERE brugerID = 1";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetAttribut(@attID bigint,@kamID bigint,@navn nvarchar(50),@infotype int,@position int)AS UPDATE Attribut SET kamID = @kamID,navn = @navn,infotype = @infotype,position = @position WHERE attID = @attID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetBruger(@brugerID bigint,@navn nvarchar(50),@fdsldag date,@tlf bigint,@nød_tlf bigint,@vegetar bit,@veganer bit,@allergi nvarchar(100),@andet nvarchar(500))AS UPDATE Bruger SET navn = @navn,fødselsdag = @fdsldag,tlf = @tlf,nød_tlf = @nød_tlf,vegetar = @vegetar,veganer = @veganer,allergi = @allergi,andet = @andet WHERE brugerID = @brugerID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetKampagneBeskrivelse(@kamID bigint,@beskrivelse nvarchar(500))AS UPDATE Kampagne SET beskrivelse = @beskrivelse WHERE kamID = @kamID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetKampagneHjemmeside(@kamID bigint,@hjemmeside nvarchar(150))AS UPDATE Kampagne SET hjemmeside = @hjemmeside WHERE kamID = @kamID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetKampagneNavn(@kamID bigint, @navn nvarchar(50))AS UPDATE Kampagne SET navn = @navn WHERE kamID = @kamID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetKampagneStatus (@kamID bigint,@status int )as update Kampagne set [status] = @status where kamID = @kamID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetKarakterStatus (@karakterID bigint,@status int )as update Karakter set [karstatus] = @status where karakterID = @karakterID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetMultiAttributEntry(@entryID bigint,@attID bigint,@værdi nvarchar(50))AS UPDATE MultiAttributEntry SET attID = @attID, værdi = @værdi WHERE entryID = @entryID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE RetScenarie (@scenarieID BIGINT,@titel NVARCHAR(50),@beskrivelse NVARCHAR(4000),@dato DATETIME,@sted NVARCHAR(50),@pris DECIMAL(7,2),@overnatning INT,@overnatningTvungen BIT,@spisning BIT,@spisningTvungen BIT,@andetInfo NVARCHAR(4000))AS UPDATE Scenarie SET titel = @titel, beskrivelse = @beskrivelse, dato = @dato, sted = @sted, overnatning = @overnatning, overnatningTvungen = @overnatningTvungen, spisning = @spisning, spisningTvungen = @spisningTvungen, andetInfo = @andetInfo WHERE scenarieID = @scenarieID;";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE SletAttribut(@attID bigint)AS DELETE FROM MultiAttributEntry WHERE attID = @attID DELETE FROM Attribut WHERE attID = @attID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE SletAttributer AS DELETE FROM MultiAttributEntry DELETE FROM Attribut";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE SletMultiAttribut(@entryID bigint) AS DELETE FROM MultiAttributEntry WHERE entryID = @entryID";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "CREATE PROCEDURE TilmeldKarakterTilScenarie(@karakterID BIGINT,@scenarieID BIGINT,@antalOvernatninger INT,@spiser BIT)AS INSERT INTO Tilmelding VALUES (@karakterID, @scenarieID, @antalOvernatninger, @spiser)";
				cmd.ExecuteNonQuery();
				conn.Close();
				return 0;//success
			}
			catch (Exception)
			{
				if (conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
				return 1;//database error
			}
			
		}
	}
}
