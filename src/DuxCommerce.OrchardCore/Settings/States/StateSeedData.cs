﻿using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.States;

public static class StateSeedData
{
    // This site or product includes IP2Location™ ISO 3166-2 Subdivision Code which available from https://www.ip2location.com. 
    private const string States =
        @"AD;Andorra la Vella;AD-07
AD;Canillo;AD-02
AD;Encamp;AD-03
AD;Escaldes-Engordany;AD-08
AD;La Massana;AD-04
AD;Ordino;AD-05
AD;Sant Julia de Loria;AD-06
AE;'Ajman;AE-AJ
AE;Abu Zaby;AE-AZ
AE;Al Fujayrah;AE-FU
AE;Ash Shariqah;AE-SH
AE;Dubayy;AE-DU
AE;Ra's al Khaymah;AE-RK
AE;Umm al Qaywayn;AE-UQ
AF;Badghis;AF-BDG
AF;Baghlan;AF-BGL
AF;Balkh;AF-BAL
AF;Bamyan;AF-BAM
AF;Daykundi;AF-DAY
AF;Farah;AF-FRA
AF;Faryab;AF-FYB
AF;Ghazni;AF-GHA
AF;Ghor;AF-GHO
AF;Helmand;AF-HEL
AF;Herat;AF-HER
AF;Jowzjan;AF-JOW
AF;Kabul;AF-KAB
AF;Kandahar;AF-KAN
AF;Khost;AF-KHO
AF;Kunar;AF-KNR
AF;Kunduz;AF-KDZ
AF;Laghman;AF-LAG
AF;Logar;AF-LOG
AF;Nangarhar;AF-NAN
AF;Nimroz;AF-NIM
AF;Paktika;AF-PKA
AF;Paktiya;AF-PIA
AF;Parwan;AF-PAR
AF;Samangan;AF-SAM
AF;Sar-e Pul;AF-SAR
AF;Takhar;AF-TAK
AF;Uruzgan;AF-URU
AG;Barbuda;AG-10
AG;Redonda;AG-11
AG;Saint George;AG-03
AG;Saint John;AG-04
AG;Saint Mary;AG-05
AG;Saint Paul;AG-06
AG;Saint Peter;AG-07
AG;Saint Philip;AG-08
AI;Anguilla;-
AL;Berat;AL-01
AL;Diber;AL-09
AL;Durres;AL-02
AL;Elbasan;AL-03
AL;Fier;AL-04
AL;Gjirokaster;AL-05
AL;Korce;AL-06
AL;Kukes;AL-07
AL;Lezhe;AL-08
AL;Shkoder;AL-10
AL;Tirane;AL-11
AL;Vlore;AL-12
AM;Aragacotn;AM-AG
AM;Ararat;AM-AR
AM;Armavir;AM-AV
AM;Erevan;AM-ER
AM;Gegark'unik';AM-GR
AM;Kotayk';AM-KT
AM;Lori;AM-LO
AM;Sirak;AM-SH
AM;Syunik';AM-SU
AM;Tavus;AM-TV
AM;Vayoc Jor;AM-VD
AO;Bengo;AO-BGO
AO;Benguela;AO-BGU
AO;Bie;AO-BIE
AO;Cabinda;AO-CAB
AO;Cuando Cubango;AO-CCU
AO;Cuanza-Norte;AO-CNO
AO;Cuanza-Sul;AO-CUS
AO;Cunene;AO-CNN
AO;Huambo;AO-HUA
AO;Huila;AO-HUI
AO;Luanda;AO-LUA
AO;Lunda-Norte;AO-LNO
AO;Lunda-Sul;AO-LSU
AO;Malange;AO-MAL
AO;Moxico;AO-MOX
AO;Namibe;AO-NAM
AO;Uige;AO-UIG
AO;Zaire;AO-ZAI
AQ;Antarctica;-
AR;Buenos Aires;AR-B
AR;Catamarca;AR-K
AR;Chaco;AR-H
AR;Chubut;AR-U
AR;Ciudad Autonoma de Buenos Aires;AR-C
AR;Cordoba;AR-X
AR;Corrientes;AR-W
AR;Entre Rios;AR-E
AR;Formosa;AR-P
AR;Jujuy;AR-Y
AR;La Pampa;AR-L
AR;La Rioja;AR-F
AR;Mendoza;AR-M
AR;Misiones;AR-N
AR;Neuquen;AR-Q
AR;Rio Negro;AR-R
AR;Salta;AR-A
AR;San Juan;AR-J
AR;San Luis;AR-D
AR;Santa Cruz;AR-Z
AR;Santa Fe;AR-S
AR;Santiago del Estero;AR-G
AR;Tierra del Fuego;AR-V
AR;Tucuman;AR-T
AS;Eastern District;-
AS;Western District;-
AT;Burgenland;AT-1
AT;Karnten;AT-2
AT;Niederosterreich;AT-3
AT;Oberosterreich;AT-4
AT;Salzburg;AT-5
AT;Steiermark;AT-6
AT;Tirol;AT-7
AT;Vorarlberg;AT-8
AT;Wien;AT-9
AU;Australian Capital Territory;AU-ACT
AU;New South Wales;AU-NSW
AU;Northern Territory;AU-NT
AU;Queensland;AU-QLD
AU;South Australia;AU-SA
AU;Tasmania;AU-TAS
AU;Victoria;AU-VIC
AU;Western Australia;AU-WA
AW;Aruba;-
AX;Eckeroe;-
AX;Finstroem;-
AX;Hammarland;-
AX;Jomala;-
AX;Lemland;-
AX;Mariehamn;-
AX;Saltvik;-
AX;Sund;-
AZ;Abseron;AZ-ABS
AZ;Agcabadi;AZ-AGC
AZ;Agdas;AZ-AGS
AZ;Agsu;AZ-AGU
AZ;Astara;AZ-AST
AZ;Baki;AZ-BA
AZ;Balakan;AZ-BAL
AZ;Barda;AZ-BAR
AZ;Beylaqan;AZ-BEY
AZ;Calilabad;AZ-CAL
AZ;Daskasan;AZ-DAS
AZ;Fuzuli;AZ-FUZ
AZ;Gadabay;AZ-GAD
AZ;Ganca;AZ-GA
AZ;Goranboy;AZ-GOR
AZ;Goycay;AZ-GOY
AZ;Goygol;AZ-GYG
AZ;Imisli;AZ-IMI
AZ;Ismayilli;AZ-ISM
AZ;Kurdamir;AZ-KUR
AZ;Lankaran;AZ-LA
AZ;Masalli;AZ-MAS
AZ;Mingacevir;AZ-MI
AZ;Naftalan;AZ-NA
AZ;Naxcivan;AZ-NX
AZ;Neftcala;AZ-NEF
AZ;Oguz;AZ-OGU
AZ;Qabala;AZ-QAB
AZ;Qax;AZ-QAX
AZ;Qazax;AZ-QAZ
AZ;Quba;AZ-QBA
AZ;Qusar;AZ-QUS
AZ;Saatli;AZ-SAT
AZ;Sabirabad;AZ-SAB
AZ;Saki;AZ-SAK
AZ;Salyan;AZ-SAL
AZ;Samaxi;AZ-SMI
AZ;Samkir;AZ-SKR
AZ;Samux;AZ-SMX
AZ;Sirvan;AZ-SR
AZ;Siyazan;AZ-SIY
AZ;Sumqayit;AZ-SM
AZ;Tartar;AZ-TAR
AZ;Ucar;AZ-UCA
AZ;Xacmaz;AZ-XAC
AZ;Xizi;AZ-XIZ
AZ;Yardimli;AZ-YAR
AZ;Yevlax;AZ-YEV
AZ;Zaqatala;AZ-ZAQ
AZ;Zardab;AZ-ZAR
BA;Brcko distrikt;BA-BRC
BA;Federacija Bosne i Hercegovine;BA-BIH
BA;Republika Srpska;BA-SRP
BB;Christ Church;BB-01
BB;Saint Andrew;BB-02
BB;Saint George;BB-03
BB;Saint James;BB-04
BB;Saint John;BB-05
BB;Saint Lucy;BB-07
BB;Saint Michael;BB-08
BB;Saint Peter;BB-09
BB;Saint Philip;BB-10
BB;Saint Thomas;BB-11
BD;Barishal;BD-A
BD;Chattogram;BD-B
BD;Dhaka;BD-C
BD;Khulna;BD-D
BD;Rajshahi;BD-E
BD;Rangpur;BD-F
BD;Sylhet;BD-G
BE;Antwerpen;BE-VAN
BE;Brabant wallon;BE-WBR
BE;Brussels Hoofdstedelijk Gewest;BE-BRU
BE;Hainaut;BE-WHT
BE;Liege;BE-WLG
BE;Limburg;BE-VLI
BE;Luxembourg;BE-WLX
BE;Namur;BE-WNA
BE;Oost-Vlaanderen;BE-VOV
BE;Vlaams-Brabant;BE-VBR
BE;West-Vlaanderen;BE-VWV
BF;Bale;BF-BAL
BF;Bam;BF-BAM
BF;Banwa;BF-BAN
BF;Bazega;BF-BAZ
BF;Boulgou;BF-BLG
BF;Boulkiemde;BF-BLK
BF;Comoe;BF-COM
BF;Ganzourgou;BF-GAN
BF;Gnagna;BF-GNA
BF;Gourma;BF-GOU
BF;Houet;BF-HOU
BF;Kadiogo;BF-KAD
BF;Kenedougou;BF-KEN
BF;Kompienga;BF-KMP
BF;Kossi;BF-KOS
BF;Kouritenga;BF-KOT
BF;Kourweogo;BF-KOW
BF;Leraba;BF-LER
BF;Mouhoun;BF-MOU
BF;Nahouri;BF-NAO
BF;Namentenga;BF-NAM
BF;Nayala;BF-NAY
BF;Oubritenga;BF-OUB
BF;Oudalan;BF-OUD
BF;Passore;BF-PAS
BF;Sanmatenga;BF-SMT
BF;Seno;BF-SEN
BF;Sissili;BF-SIS
BF;Soum;BF-SOM
BF;Sourou;BF-SOR
BF;Tapoa;BF-TAP
BF;Tuy;BF-TUI
BF;Yatenga;BF-YAT
BF;Ziro;BF-ZIR
BF;Zondoma;BF-ZON
BF;Zoundweogo;BF-ZOU
BG;Blagoevgrad;BG-01
BG;Burgas;BG-02
BG;Dobrich;BG-08
BG;Gabrovo;BG-07
BG;Haskovo;BG-26
BG;Kardzhali;BG-09
BG;Kyustendil;BG-10
BG;Lovech;BG-11
BG;Montana;BG-12
BG;Pazardzhik;BG-13
BG;Pernik;BG-14
BG;Pleven;BG-15
BG;Plovdiv;BG-16
BG;Razgrad;BG-17
BG;Ruse;BG-18
BG;Shumen;BG-27
BG;Silistra;BG-19
BG;Sliven;BG-20
BG;Smolyan;BG-21
BG;Sofia;BG-23
BG;Sofia (stolitsa);BG-22
BG;Stara Zagora;BG-24
BG;Targovishte;BG-25
BG;Varna;BG-03
BG;Veliko Tarnovo;BG-04
BG;Vidin;BG-05
BG;Vratsa;BG-06
BG;Yambol;BG-28
BH;Al 'Asimah;BH-13
BH;Al Janubiyah;BH-14
BH;Al Muharraq;BH-15
BH;Ash Shamaliyah;BH-17
BI;Bujumbura Mairie;BI-BM
BI;Bururi;BI-BR
BI;Cibitoke;BI-CI
BI;Gitega;BI-GI
BI;Kirundo;BI-KI
BI;Mwaro;BI-MW
BI;Ngozi;BI-NG
BI;Rumonge;BI-RM
BI;Rutana;BI-RT
BI;Ruyigi;BI-RY
BJ;Atlantique;BJ-AQ
BJ;Borgou;BJ-BO
BJ;Collines;BJ-CO
BJ;Littoral;BJ-LI
BJ;Mono;BJ-MO
BJ;Oueme;BJ-OU
BJ;Plateau;BJ-PL
BJ;Zou;BJ-ZO
BL;Saint Barthelemy;-
BM;Hamilton;-
BM;Saint George;-
BN;Belait;BN-BE
BN;Brunei-Muara;BN-BM
BN;Temburong;BN-TE
BN;Tutong;BN-TU
BO;Chuquisaca;BO-H
BO;Cochabamba;BO-C
BO;El Beni;BO-B
BO;La Paz;BO-L
BO;Oruro;BO-O
BO;Pando;BO-N
BO;Potosi;BO-P
BO;Santa Cruz;BO-S
BO;Tarija;BO-T
BQ;Bonaire;BQ-BO
BQ;Saba;BQ-SA
BQ;Sint Eustatius;BQ-SE
BR;Acre;BR-AC
BR;Alagoas;BR-AL
BR;Amapa;BR-AP
BR;Amazonas;BR-AM
BR;Bahia;BR-BA
BR;Ceara;BR-CE
BR;Distrito Federal;BR-DF
BR;Espirito Santo;BR-ES
BR;Goias;BR-GO
BR;Maranhao;BR-MA
BR;Mato Grosso;BR-MT
BR;Mato Grosso do Sul;BR-MS
BR;Minas Gerais;BR-MG
BR;Para;BR-PA
BR;Paraiba;BR-PB
BR;Parana;BR-PR
BR;Pernambuco;BR-PE
BR;Piaui;BR-PI
BR;Rio Grande do Norte;BR-RN
BR;Rio Grande do Sul;BR-RS
BR;Rio de Janeiro;BR-RJ
BR;Rondonia;BR-RO
BR;Roraima;BR-RR
BR;Santa Catarina;BR-SC
BR;Sao Paulo;BR-SP
BR;Sergipe;BR-SE
BR;Tocantins;BR-TO
BS;Black Point;BS-BP
BS;Central Abaco;BS-CO
BS;City of Freeport;BS-FP
BS;East Grand Bahama;BS-EG
BS;Harbour Island;BS-HI
BS;Long Island;BS-LI
BS;New Providence;BS-NP
BS;North Andros;BS-NS
BS;North Eleuthera;BS-NE
BS;South Eleuthera;BS-SE
BS;West Grand Bahama;BS-WG
BT;Bumthang;BT-33
BT;Chhukha;BT-12
BT;Dagana;BT-22
BT;Gasa;BT-GA
BT;Lhuentse;BT-44
BT;Monggar;BT-42
BT;Paro;BT-11
BT;Pema Gatshel;BT-43
BT;Punakha;BT-23
BT;Samdrup Jongkhar;BT-45
BT;Samtse;BT-14
BT;Sarpang;BT-31
BT;Thimphu;BT-15
BT;Trashigang;BT-41
BT;Trongsa;BT-32
BT;Tsirang;BT-21
BT;Wangdue Phodrang;BT-24
BV;Bouvet Island;-
BW;Central;BW-CE
BW;Chobe;BW-CH
BW;Ghanzi;BW-GH
BW;Kgalagadi;BW-KG
BW;Kgatleng;BW-KL
BW;Kweneng;BW-KW
BW;North East;BW-NE
BW;North West;BW-NW
BW;South East;BW-SE
BW;Southern;BW-SO
BY;Brestskaya voblasts';BY-BR
BY;Homyel'skaya voblasts';BY-HO
BY;Horad Minsk;BY-HM
BY;Hrodzyenskaya voblasts';BY-HR
BY;Mahilyowskaya voblasts';BY-MA
BY;Minskaya voblasts';BY-MI
BY;Vitsyebskaya voblasts';BY-VI
BZ;Belize;BZ-BZ
BZ;Cayo;BZ-CY
BZ;Corozal;BZ-CZL
BZ;Orange Walk;BZ-OW
BZ;Stann Creek;BZ-SC
BZ;Toledo;BZ-TOL
CA;Alberta;CA-AB
CA;British Columbia;CA-BC
CA;Manitoba;CA-MB
CA;New Brunswick;CA-NB
CA;Newfoundland and Labrador;CA-NL
CA;Northwest Territories;CA-NT
CA;Nova Scotia;CA-NS
CA;Nunavut;CA-NU
CA;Ontario;CA-ON
CA;Prince Edward Island;CA-PE
CA;Quebec;CA-QC
CA;Saskatchewan;CA-SK
CA;Yukon;CA-YT
CC;Cocos (Keeling) Islands;-
CD;Equateur;CD-EQ
CD;Haut-Katanga;CD-HK
CD;Ituri;CD-IT
CD;Kasai Central;CD-KC
CD;Kasai Oriental;CD-KE
CD;Kinshasa;CD-KN
CD;Kwango;CD-KG
CD;Kwilu;CD-KL
CD;Lualaba;CD-LU
CD;Maniema;CD-MA
CD;Nord-Kivu;CD-NK
CD;Sankuru;CD-SA
CD;Sud-Kivu;CD-SK
CD;Tanganyika;CD-TA
CD;Tshopo;CD-TO
CF;Bamingui-Bangoran;CF-BB
CF;Bangui;CF-BGF
CF;Gribingui;CF-KB
CF;Kemo-Gribingui;CF-KG
CF;Nana-Mambere;CF-NM
CF;Ouaka;CF-UK
CF;Ouham;CF-AC
CF;Ouham-Pende;CF-OP
CF;Sangha;CF-SE
CF;Vakaga;CF-VK
CG;Bouenza;CG-11
CG;Brazzaville;CG-BZV
CG;Cuvette;CG-8
CG;Niari;CG-9
CG;Pointe-Noire;CG-16
CG;Sangha;CG-13
CH;Aargau;CH-AG
CH;Appenzell Ausserrhoden;CH-AR
CH;Appenzell Innerrhoden;CH-AI
CH;Basel-Landschaft;CH-BL
CH;Basel-Stadt;CH-BS
CH;Bern;CH-BE
CH;Fribourg;CH-FR
CH;Geneve;CH-GE
CH;Glarus;CH-GL
CH;Graubunden;CH-GR
CH;Jura;CH-JU
CH;Luzern;CH-LU
CH;Neuchatel;CH-NE
CH;Nidwalden;CH-NW
CH;Obwalden;CH-OW
CH;Sankt Gallen;CH-SG
CH;Schaffhausen;CH-SH
CH;Schwyz;CH-SZ
CH;Solothurn;CH-SO
CH;Thurgau;CH-TG
CH;Ticino;CH-TI
CH;Uri;CH-UR
CH;Valais;CH-VS
CH;Vaud;CH-VD
CH;Zug;CH-ZG
CH;Zurich;CH-ZH
CI;Abidjan;CI-AB
CI;Bas-Sassandra;CI-BS
CI;Comoe;CI-CM
CI;Denguele;CI-DN
CI;Goh-Djiboua;CI-GD
CI;Lacs;CI-LC
CI;Lagunes;CI-LG
CI;Montagnes;CI-MG
CI;Sassandra-Marahoue;CI-SM
CI;Savanes;CI-SV
CI;Vallee du Bandama;CI-VB
CI;Woroba;CI-WR
CI;Yamoussoukro;CI-YM
CI;Zanzan;CI-ZZ
CK;Cook Islands;-
CL;Aisen del General Carlos Ibanez del Campo;CL-AI
CL;Antofagasta;CL-AN
CL;Arica y Parinacota;CL-AP
CL;Atacama;CL-AT
CL;Biobio;CL-BI
CL;Coquimbo;CL-CO
CL;La Araucania;CL-AR
CL;Libertador General Bernardo O'Higgins;CL-LI
CL;Los Lagos;CL-LL
CL;Los Rios;CL-LR
CL;Magallanes;CL-MA
CL;Maule;CL-ML
CL;Nuble;CL-NB
CL;Region Metropolitana de Santiago;CL-RM
CL;Tarapaca;CL-TA
CL;Valparaiso;CL-VS
CM;Adamaoua;CM-AD
CM;Centre;CM-CE
CM;Est;CM-ES
CM;Extreme-Nord;CM-EN
CM;Littoral;CM-LT
CM;Nord;CM-NO
CM;Nord-Ouest;CM-NW
CM;Ouest;CM-OU
CM;Sud;CM-SU
CM;Sud-Ouest;CM-SW
CN;Anhui;CN-AH
CN;Beijing;CN-BJ
CN;Chongqing;CN-CQ
CN;Fujian;CN-FJ
CN;Gansu;CN-GS
CN;Guangdong;CN-GD
CN;Guangxi Zhuangzu;CN-GX
CN;Guizhou;CN-GZ
CN;Hainan;CN-HI
CN;Hebei;CN-HE
CN;Heilongjiang;CN-HL
CN;Henan;CN-HA
CN;Hubei;CN-HB
CN;Hunan;CN-HN
CN;Jiangsu;CN-JS
CN;Jiangxi;CN-JX
CN;Jilin;CN-JL
CN;Liaoning;CN-LN
CN;Nei Mongol;CN-NM
CN;Ningxia Huizu;CN-NX
CN;Qinghai;CN-QH
CN;Shaanxi;CN-SN
CN;Shandong;CN-SD
CN;Shanghai;CN-SH
CN;Shanxi;CN-SX
CN;Sichuan;CN-SC
CN;Tianjin;CN-TJ
CN;Xinjiang Uygur;CN-XJ
CN;Xizang;CN-XZ
CN;Yunnan;CN-YN
CN;Zhejiang;CN-ZJ
CO;Amazonas;CO-AMA
CO;Antioquia;CO-ANT
CO;Arauca;CO-ARA
CO;Atlantico;CO-ATL
CO;Bolivar;CO-BOL
CO;Boyaca;CO-BOY
CO;Caldas;CO-CAL
CO;Caqueta;CO-CAQ
CO;Casanare;CO-CAS
CO;Cauca;CO-CAU
CO;Cesar;CO-CES
CO;Choco;CO-CHO
CO;Cordoba;CO-COR
CO;Cundinamarca;CO-CUN
CO;Distrito Capital de Bogota;CO-DC
CO;Guainia;CO-GUA
CO;Guaviare;CO-GUV
CO;Huila;CO-HUI
CO;La Guajira;CO-LAG
CO;Magdalena;CO-MAG
CO;Meta;CO-MET
CO;Narino;CO-NAR
CO;Norte de Santander;CO-NSA
CO;Putumayo;CO-PUT
CO;Quindio;CO-QUI
CO;Risaralda;CO-RIS
CO;San Andres, Providencia y Santa Catalina;CO-SAP
CO;Santander;CO-SAN
CO;Sucre;CO-SUC
CO;Tolima;CO-TOL
CO;Valle del Cauca;CO-VAC
CO;Vichada;CO-VID
CR;Alajuela;CR-A
CR;Cartago;CR-C
CR;Guanacaste;CR-G
CR;Heredia;CR-H
CR;Limon;CR-L
CR;Puntarenas;CR-P
CR;San Jose;CR-SJ
CU;Artemisa;CU-15
CU;Camaguey;CU-09
CU;Ciego de Avila;CU-08
CU;Cienfuegos;CU-06
CU;Granma;CU-12
CU;Guantanamo;CU-14
CU;Holguin;CU-11
CU;Isla de la Juventud;CU-99
CU;La Habana;CU-03
CU;Las Tunas;CU-10
CU;Matanzas;CU-04
CU;Mayabeque;CU-16
CU;Pinar del Rio;CU-01
CU;Sancti Spiritus;CU-07
CU;Santiago de Cuba;CU-13
CU;Villa Clara;CU-05
CV;Boa Vista;CV-BV
CV;Brava;CV-BR
CV;Mosteiros;CV-MO
CV;Porto Novo;CV-PN
CV;Praia;CV-PR
CV;Ribeira Grande de Santiago;CV-RS
CV;Sal;CV-SL
CV;Sao Domingos;CV-SD
CV;Sao Vicente;CV-SV
CV;Tarrafal;CV-TA
CV;Tarrafal de Sao Nicolau;CV-TS
CW;Curacao;-
CX;Christmas Island;-
CY;Ammochostos;CY-04
CY;Keryneia;CY-06
CY;Larnaka;CY-03
CY;Lefkosia;CY-01
CY;Lemesos;CY-02
CY;Pafos;CY-05
CZ;Jihocesky kraj;CZ-31
CZ;Jihomoravsky kraj;CZ-64
CZ;Karlovarsky kraj;CZ-41
CZ;Kraj Vysocina;CZ-63
CZ;Kralovehradecky kraj;CZ-52
CZ;Liberecky kraj;CZ-51
CZ;Moravskoslezsky kraj;CZ-80
CZ;Olomoucky kraj;CZ-71
CZ;Pardubicky kraj;CZ-53
CZ;Plzensky kraj;CZ-32
CZ;Praha, Hlavni mesto;CZ-10
CZ;Stredocesky kraj;CZ-20
CZ;Ustecky kraj;CZ-42
CZ;Zlinsky kraj;CZ-72
DE;Baden-Wurttemberg;DE-BW
DE;Bayern;DE-BY
DE;Berlin;DE-BE
DE;Brandenburg;DE-BB
DE;Bremen;DE-HB
DE;Hamburg;DE-HH
DE;Hessen;DE-HE
DE;Mecklenburg-Vorpommern;DE-MV
DE;Niedersachsen;DE-NI
DE;Nordrhein-Westfalen;DE-NW
DE;Rheinland-Pfalz;DE-RP
DE;Saarland;DE-SL
DE;Sachsen;DE-SN
DE;Sachsen-Anhalt;DE-ST
DE;Schleswig-Holstein;DE-SH
DE;Thuringen;DE-TH
DJ;Arta;DJ-AR
DJ;Dikhil;DJ-DI
DJ;Djibouti;DJ-DJ
DK;Hovedstaden;DK-84
DK;Midtjylland;DK-82
DK;Nordjylland;DK-81
DK;Sjaelland;DK-85
DK;Syddanmark;DK-83
DM;Saint Andrew;DM-02
DM;Saint George;DM-04
DM;Saint John;DM-05
DM;Saint Joseph;DM-06
DM;Saint Luke;DM-07
DM;Saint Mark;DM-08
DM;Saint Patrick;DM-09
DM;Saint Paul;DM-10
DO;Azua;DO-02
DO;Baoruco;DO-03
DO;Barahona;DO-04
DO;Dajabon;DO-05
DO;Distrito Nacional (Santo Domingo);DO-01
DO;Duarte;DO-06
DO;El Seibo;DO-08
DO;Elias Pina;DO-07
DO;Espaillat;DO-09
DO;Hato Mayor;DO-30
DO;Hermanas Mirabal;DO-19
DO;Independencia;DO-10
DO;La Altagracia;DO-11
DO;La Romana;DO-12
DO;La Vega;DO-13
DO;Maria Trinidad Sanchez;DO-14
DO;Monsenor Nouel;DO-28
DO;Monte Cristi;DO-15
DO;Monte Plata;DO-29
DO;Pedernales;DO-16
DO;Peravia;DO-17
DO;Puerto Plata;DO-18
DO;Samana;DO-20
DO;San Cristobal;DO-21
DO;San Jose de Ocoa;DO-31
DO;San Juan;DO-22
DO;San Pedro de Macoris;DO-23
DO;Sanchez Ramirez;DO-24
DO;Santiago;DO-25
DO;Santiago Rodriguez;DO-26
DO;Valverde;DO-27
DZ;Adrar;DZ-01
DZ;Ain Defla;DZ-44
DZ;Ain Temouchent;DZ-46
DZ;Alger;DZ-16
DZ;Annaba;DZ-23
DZ;Batna;DZ-05
DZ;Bechar;DZ-08
DZ;Bejaia;DZ-06
DZ;Biskra;DZ-07
DZ;Blida;DZ-09
DZ;Bordj Bou Arreridj;DZ-34
DZ;Bouira;DZ-10
DZ;Boumerdes;DZ-35
DZ;Chlef;DZ-02
DZ;Constantine;DZ-25
DZ;Djelfa;DZ-17
DZ;El Bayadh;DZ-32
DZ;El Oued;DZ-39
DZ;El Tarf;DZ-36
DZ;Ghardaia;DZ-47
DZ;Guelma;DZ-24
DZ;Illizi;DZ-33
DZ;Jijel;DZ-18
DZ;Khenchela;DZ-40
DZ;Laghouat;DZ-03
DZ;M'sila;DZ-28
DZ;Mascara;DZ-29
DZ;Medea;DZ-26
DZ;Mila;DZ-43
DZ;Mostaganem;DZ-27
DZ;Naama;DZ-45
DZ;Oran;DZ-31
DZ;Ouargla;DZ-30
DZ;Oum el Bouaghi;DZ-04
DZ;Relizane;DZ-48
DZ;Saida;DZ-20
DZ;Setif;DZ-19
DZ;Sidi Bel Abbes;DZ-22
DZ;Skikda;DZ-21
DZ;Souk Ahras;DZ-41
DZ;Tamanrasset;DZ-11
DZ;Tebessa;DZ-12
DZ;Tiaret;DZ-14
DZ;Tindouf;DZ-37
DZ;Tipaza;DZ-42
DZ;Tissemsilt;DZ-38
DZ;Tizi Ouzou;DZ-15
DZ;Tlemcen;DZ-13
EC;Azuay;EC-A
EC;Bolivar;EC-B
EC;Canar;EC-F
EC;Carchi;EC-C
EC;Chimborazo;EC-H
EC;Cotopaxi;EC-X
EC;El Oro;EC-O
EC;Esmeraldas;EC-E
EC;Galapagos;EC-W
EC;Guayas;EC-G
EC;Imbabura;EC-I
EC;Loja;EC-L
EC;Los Rios;EC-R
EC;Manabi;EC-M
EC;Morona Santiago;EC-S
EC;Napo;EC-N
EC;Orellana;EC-D
EC;Pastaza;EC-Y
EC;Pichincha;EC-P
EC;Santa Elena;EC-SE
EC;Santo Domingo de los Tsachilas;EC-SD
EC;Sucumbios;EC-U
EC;Tungurahua;EC-T
EC;Zamora Chinchipe;EC-Z
EE;Harjumaa;EE-37
EE;Hiiumaa;EE-39
EE;Ida-Virumaa;EE-45
EE;Jarvamaa;EE-52
EE;Jogevamaa;EE-50
EE;Laane-Virumaa;EE-60
EE;Laanemaa;EE-56
EE;Parnumaa;EE-68
EE;Polvamaa;EE-64
EE;Raplamaa;EE-71
EE;Saaremaa;EE-74
EE;Tartumaa;EE-79
EE;Valgamaa;EE-81
EE;Viljandimaa;EE-84
EE;Vorumaa;EE-87
EG;Ad Daqahliyah;EG-DK
EG;Al Bahr al Ahmar;EG-BA
EG;Al Buhayrah;EG-BH
EG;Al Fayyum;EG-FYM
EG;Al Gharbiyah;EG-GH
EG;Al Iskandariyah;EG-ALX
EG;Al Isma'iliyah;EG-IS
EG;Al Jizah;EG-GZ
EG;Al Minufiyah;EG-MNF
EG;Al Minya;EG-MN
EG;Al Qahirah;EG-C
EG;Al Qalyubiyah;EG-KB
EG;Al Uqsur;EG-LX
EG;Al Wadi al Jadid;EG-WAD
EG;As Suways;EG-SUZ
EG;Ash Sharqiyah;EG-SHR
EG;Aswan;EG-ASN
EG;Asyut;EG-AST
EG;Bani Suwayf;EG-BNS
EG;Bur Sa'id;EG-PTS
EG;Dumyat;EG-DT
EG;Janub Sina';EG-JS
EG;Kafr ash Shaykh;EG-KFS
EG;Matruh;EG-MT
EG;Qina;EG-KN
EG;Shamal Sina';EG-SIN
EG;Suhaj;EG-SHG
EH;Western Sahara;-
ER;Al Awsat;ER-MA
ER;Qash-Barkah;ER-GB
ES;Andalucia;ES-AN
ES;Aragon;ES-AR
ES;Asturias, Principado de;ES-AS
ES;Canarias;ES-CN
ES;Cantabria;ES-CB
ES;Castilla y Leon;ES-CL
ES;Castilla-La Mancha;ES-CM
ES;Catalunya;ES-CT
ES;Ceuta;ES-CE
ES;Extremadura;ES-EX
ES;Galicia;ES-GA
ES;Illes Balears;ES-IB
ES;La Rioja;ES-RI
ES;Madrid, Comunidad de;ES-MD
ES;Melilla;ES-ML
ES;Murcia, Region de;ES-MC
ES;Navarra, Comunidad Foral de;ES-NC
ES;Pais Vasco;ES-PV
ES;Valenciana, Comunidad;ES-VC
ET;Adis Abeba;ET-AA
ET;Afar;ET-AF
ET;Amara;ET-AM
ET;Binshangul Gumuz;ET-BE
ET;Dire Dawa;ET-DD
ET;Gambela Hizboch;ET-GA
ET;Hareri Hizb;ET-HA
ET;Oromiya;ET-OR
ET;Sumale;ET-SO
ET;Tigray;ET-TI
ET;YeDebub Biheroch Bihereseboch na Hizboch;ET-SN
FI;Etela-Karjala;FI-02
FI;Etela-Pohjanmaa;FI-03
FI;Etela-Savo;FI-04
FI;Kainuu;FI-05
FI;Kanta-Hame;FI-06
FI;Keski-Pohjanmaa;FI-07
FI;Keski-Suomi;FI-08
FI;Kymenlaakso;FI-09
FI;Lappi;FI-10
FI;Paijat-Hame;FI-16
FI;Pirkanmaa;FI-11
FI;Pohjanmaa;FI-12
FI;Pohjois-Karjala;FI-13
FI;Pohjois-Pohjanmaa;FI-14
FI;Pohjois-Savo;FI-15
FI;Satakunta;FI-17
FI;Uusimaa;FI-18
FI;Varsinais-Suomi;FI-19
FJ;Central;FJ-C
FJ;Eastern;FJ-E
FJ;Northern;FJ-N
FJ;Rotuma;FJ-R
FJ;Western;FJ-W
FK;Falkland Islands (Malvinas);-
FM;Chuuk;FM-TRK
FM;Kosrae;FM-KSA
FM;Pohnpei;FM-PNI
FM;Yap;FM-YAP
FO;Eysturoy;-
FO;Nordoyar;-
FO;Streymoy;-
FO;Suduroy;-
FO;Vagar;-
FR;Auvergne-Rhone-Alpes;FR-ARA
FR;Bourgogne-Franche-Comte;FR-BFC
FR;Bretagne;FR-BRE
FR;Centre-Val de Loire;FR-CVL
FR;Corse;FR-20R
FR;Grand-Est;FR-GES
FR;Hauts-de-France;FR-HDF
FR;Ile-de-France;FR-IDF
FR;Normandie;FR-NOR
FR;Nouvelle-Aquitaine;FR-NAQ
FR;Occitanie;FR-OCC
FR;Pays-de-la-Loire;FR-PDL
FR;Provence-Alpes-Cote-d'Azur;FR-PAC
GA;Estuaire;GA-1
GA;Haut-Ogooue;GA-2
GA;Moyen-Ogooue;GA-3
GA;Ngounie;GA-4
GA;Nyanga;GA-5
GA;Ogooue-Maritime;GA-8
GA;Woleu-Ntem;GA-9
GB;England;GB-ENG
GB;Northern Ireland;GB-NIR
GB;Scotland;GB-SCT
GB;Wales;GB-WLS
GD;Saint Andrew;GD-01
GD;Saint David;GD-02
GD;Saint George;GD-03
GD;Saint John;GD-04
GD;Saint Mark;GD-05
GD;Saint Patrick;GD-06
GD;Southern Grenadine Islands;GD-10
GE;Abkhazia;GE-AB
GE;Ajaria;GE-AJ
GE;Guria;GE-GU
GE;Imereti;GE-IM
GE;K'akheti;GE-KA
GE;Kvemo Kartli;GE-KK
GE;Mtskheta-Mtianeti;GE-MM
GE;Rach'a-Lechkhumi-Kvemo Svaneti;GE-RL
GE;Samegrelo-Zemo Svaneti;GE-SZ
GE;Samtskhe-Javakheti;GE-SJ
GE;Shida Kartli;GE-SK
GE;Tbilisi;GE-TB
GF;Guyane;-
GG;Guernsey;-
GH;Ahafo;GH-AF
GH;Ashanti;GH-AH
GH;Bono;GH-BO
GH;Bono East;GH-BE
GH;Central;GH-CP
GH;Eastern;GH-EP
GH;Greater Accra;GH-AA
GH;Northern;GH-NP
GH;Upper East;GH-UE
GH;Upper West;GH-UW
GH;Volta;GH-TV
GH;Western;GH-WP
GI;Gibraltar;-
GL;Avannaata Kommunia;GL-AV
GL;Kommune Kujalleq;GL-KU
GL;Kommune Qeqertalik;GL-QT
GL;Kommuneqarfik Sermersooq;GL-SM
GL;Qeqqata Kommunia;GL-QE
GM;Banjul;GM-B
GM;Central River;GM-M
GM;Lower River;GM-L
GM;North Bank;GM-N
GM;Upper River;GM-U
GM;Western;GM-W
GN;Boffa;GN-BF
GN;Boke;GN-B
GN;Conakry;GN-C
GN;Coyah;GN-CO
GN;Dabola;GN-DB
GN;Dalaba;GN-DL
GN;Dinguiraye;GN-DI
GN;Dubreka;GN-DU
GN;Fria;GN-FR
GN;Kankan;GN-K
GN;Kouroussa;GN-KO
GN;Labe;GN-L
GN;Labe;GN-LA
GN;Nzerekore;GN-N
GN;Siguiri;GN-SI
GP;Guadeloupe;-
GQ;Bioko Norte;GQ-BN
GQ;Centro Sur;GQ-CS
GQ;Kie-Ntem;GQ-KN
GQ;Litoral;GQ-LI
GQ;Wele-Nzas;GQ-WN
GR;Agion Oros;GR-69
GR;Anatoliki Makedonia kai Thraki;GR-A
GR;Attiki;GR-I
GR;Dytiki Ellada;GR-G
GR;Dytiki Makedonia;GR-C
GR;Ionia Nisia;GR-F
GR;Ipeiros;GR-D
GR;Kentriki Makedonia;GR-B
GR;Kriti;GR-M
GR;Notio Aigaio;GR-L
GR;Peloponnisos;GR-J
GR;Sterea Ellada;GR-H
GR;Thessalia;GR-E
GR;Voreio Aigaio;GR-K
GS;South Georgia and the South Sandwich Islands;-
GT;Alta Verapaz;GT-16
GT;Baja Verapaz;GT-15
GT;Chimaltenango;GT-04
GT;Chiquimula;GT-20
GT;El Progreso;GT-02
GT;Escuintla;GT-05
GT;Guatemala;GT-01
GT;Huehuetenango;GT-13
GT;Izabal;GT-18
GT;Jalapa;GT-21
GT;Jutiapa;GT-22
GT;Peten;GT-17
GT;Quetzaltenango;GT-09
GT;Quiche;GT-14
GT;Retalhuleu;GT-11
GT;Sacatepequez;GT-03
GT;San Marcos;GT-12
GT;Santa Rosa;GT-06
GT;Solola;GT-07
GT;Suchitepequez;GT-10
GT;Totonicapan;GT-08
GT;Zacapa;GT-19
GU;Agana Heights;-
GU;Agat;-
GU;Barrigada;-
GU;Chalan Pago-Ordot;-
GU;Dededo;-
GU;Hagatna;-
GU;Inarajan;-
GU;Mangilao;-
GU;Mongmong-Toto-Maite;-
GU;Piti;-
GU;Santa Rita;-
GU;Sinajana;-
GU;Talofofo;-
GU;Tamuning-Tumon-Harmon;-
GU;Yigo;-
GU;Yona;-
GW;Bafata;GW-BA
GW;Bissau;GW-BS
GW;Cacheu;GW-CA
GW;Gabu;GW-GA
GW;Oio;GW-OI
GW;Tombali;GW-TO
GY;Cuyuni-Mazaruni;GY-CU
GY;Demerara-Mahaica;GY-DE
GY;East Berbice-Corentyne;GY-EB
GY;Essequibo Islands-West Demerara;GY-ES
GY;Mahaica-Berbice;GY-MA
GY;Potaro-Siparuni;GY-PT
GY;Upper Demerara-Berbice;GY-UD
HK;Hong Kong;-
HM;Heard Island and McDonald Islands;-
HN;Atlantida;HN-AT
HN;Choluteca;HN-CH
HN;Colon;HN-CL
HN;Comayagua;HN-CM
HN;Copan;HN-CP
HN;Cortes;HN-CR
HN;El Paraiso;HN-EP
HN;Francisco Morazan;HN-FM
HN;Gracias a Dios;HN-GD
HN;Intibuca;HN-IN
HN;Islas de la Bahia;HN-IB
HN;La Paz;HN-LP
HN;Lempira;HN-LE
HN;Ocotepeque;HN-OC
HN;Olancho;HN-OL
HN;Santa Barbara;HN-SB
HN;Valle;HN-VA
HN;Yoro;HN-YO
HR;Bjelovarsko-bilogorska zupanija;HR-07
HR;Brodsko-posavska zupanija;HR-12
HR;Dubrovacko-neretvanska zupanija;HR-19
HR;Grad Zagreb;HR-21
HR;Istarska zupanija;HR-18
HR;Karlovacka zupanija;HR-04
HR;Koprivnicko-krizevacka zupanija;HR-06
HR;Krapinsko-zagorska zupanija;HR-02
HR;Licko-senjska zupanija;HR-09
HR;Medimurska zupanija;HR-20
HR;Osjecko-baranjska zupanija;HR-14
HR;Pozesko-slavonska zupanija;HR-11
HR;Primorsko-goranska zupanija;HR-08
HR;Sibensko-kninska zupanija;HR-15
HR;Sisacko-moslavacka zupanija;HR-03
HR;Splitsko-dalmatinska zupanija;HR-17
HR;Varazdinska zupanija;HR-05
HR;Viroviticko-podravska zupanija;HR-10
HR;Vukovarsko-srijemska zupanija;HR-16
HR;Zadarska zupanija;HR-13
HR;Zagrebacka zupanija;HR-01
HT;Artibonite;HT-AR
HT;Centre;HT-CE
HT;Grande'Anse;HT-GA
HT;Nippes;HT-NI
HT;Nord;HT-ND
HT;Nord-Ouest;HT-NO
HT;Ouest;HT-OU
HT;Sud;HT-SD
HT;Sud-Est;HT-SE
HU;Bacs-Kiskun;HU-BK
HU;Baranya;HU-BA
HU;Bekes;HU-BE
HU;Borsod-Abauj-Zemplen;HU-BZ
HU;Budapest;HU-BU
HU;Csongrad-Csanad;HU-CS
HU;Fejer;HU-FE
HU;Gyor-Moson-Sopron;HU-GS
HU;Hajdu-Bihar;HU-HB
HU;Heves;HU-HE
HU;Jasz-Nagykun-Szolnok;HU-JN
HU;Komarom-Esztergom;HU-KE
HU;Nograd;HU-NO
HU;Pest;HU-PE
HU;Somogy;HU-SO
HU;Szabolcs-Szatmar-Bereg;HU-SZ
HU;Tolna;HU-TO
HU;Vas;HU-VA
HU;Veszprem;HU-VE
HU;Zala;HU-ZA
ID;Aceh;ID-AC
ID;Bali;ID-BA
ID;Banten;ID-BT
ID;Bengkulu;ID-BE
ID;Gorontalo;ID-GO
ID;Jakarta Raya;ID-JK
ID;Jambi;ID-JA
ID;Jawa Barat;ID-JB
ID;Jawa Tengah;ID-JT
ID;Jawa Timur;ID-JI
ID;Kalimantan Barat;ID-KB
ID;Kalimantan Selatan;ID-KS
ID;Kalimantan Tengah;ID-KT
ID;Kalimantan Timur;ID-KI
ID;Kalimantan Utara;ID-KU
ID;Kepulauan Bangka Belitung;ID-BB
ID;Kepulauan Riau;ID-KR
ID;Lampung;ID-LA
ID;Maluku;ID-ML
ID;Maluku Utara;ID-MU
ID;Nusa Tenggara Barat;ID-NB
ID;Nusa Tenggara Timur;ID-NT
ID;Papua;ID-PP
ID;Papua Barat;ID-PB
ID;Riau;ID-RI
ID;Sulawesi Barat;ID-SR
ID;Sulawesi Selatan;ID-SN
ID;Sulawesi Tengah;ID-ST
ID;Sulawesi Tenggara;ID-SG
ID;Sulawesi Utara;ID-SA
ID;Sumatera Barat;ID-SB
ID;Sumatera Selatan;ID-SS
ID;Sumatera Utara;ID-SU
ID;Yogyakarta;ID-YO
IE;Carlow;IE-CW
IE;Cavan;IE-CN
IE;Clare;IE-CE
IE;Cork;IE-CO
IE;Donegal;IE-DL
IE;Dublin;IE-D
IE;Galway;IE-G
IE;Kerry;IE-KY
IE;Kildare;IE-KE
IE;Kilkenny;IE-KK
IE;Laois;IE-LS
IE;Leitrim;IE-LM
IE;Limerick;IE-LK
IE;Longford;IE-LD
IE;Louth;IE-LH
IE;Mayo;IE-MO
IE;Meath;IE-MH
IE;Monaghan;IE-MN
IE;Offaly;IE-OY
IE;Roscommon;IE-RN
IE;Sligo;IE-SO
IE;Tipperary;IE-TA
IE;Waterford;IE-WD
IE;Westmeath;IE-WH
IE;Wexford;IE-WX
IE;Wicklow;IE-WW
IL;HaDarom;IL-D
IL;HaMerkaz;IL-M
IL;HaTsafon;IL-Z
IL;Hefa;IL-HA
IL;Tel Aviv;IL-TA
IL;Yerushalayim;IL-JM
IM;Isle of Man;-
IN;Andaman and Nicobar Islands;IN-AN
IN;Andhra Pradesh;IN-AP
IN;Arunachal Pradesh;IN-AR
IN;Assam;IN-AS
IN;Bihar;IN-BR
IN;Chandigarh;IN-CH
IN;Chhattisgarh;IN-CT
IN;Dadra and Nagar Haveli;IN-DN
IN;Dadra and Nagar Haveli and Daman and Diu;IN-DH
IN;Delhi;IN-DL
IN;Goa;IN-GA
IN;Gujarat;IN-GJ
IN;Haryana;IN-HR
IN;Himachal Pradesh;IN-HP
IN;Jammu and Kashmir;IN-JK
IN;Jharkhand;IN-JH
IN;Karnataka;IN-KA
IN;Kerala;IN-KL
IN;Lakshadweep;IN-LD
IN;Madhya Pradesh;IN-MP
IN;Maharashtra;IN-MH
IN;Manipur;IN-MN
IN;Meghalaya;IN-ML
IN;Mizoram;IN-MZ
IN;Nagaland;IN-NL
IN;Odisha;IN-OR
IN;Puducherry;IN-PY
IN;Punjab;IN-PB
IN;Rajasthan;IN-RJ
IN;Sikkim;IN-SK
IN;Tamil Nadu;IN-TN
IN;Telangana;IN-TG
IN;Tripura;IN-TR
IN;Uttar Pradesh;IN-UP
IN;Uttarakhand;IN-UT
IN;West Bengal;IN-WB
IO;British Indian Ocean Territory;-
IQ;Al Anbar;IQ-AN
IQ;Al Basrah;IQ-BA
IQ;Al Muthanna;IQ-MU
IQ;Al Qadisiyah;IQ-QA
IQ;An Najaf;IQ-NA
IQ;Arbil;IQ-AR
IQ;As Sulaymaniyah;IQ-SU
IQ;Babil;IQ-BB
IQ;Baghdad;IQ-BG
IQ;Dahuk;IQ-DA
IQ;Dhi Qar;IQ-DQ
IQ;Diyala;IQ-DI
IQ;Karbala';IQ-KA
IQ;Kirkuk;IQ-KI
IQ;Maysan;IQ-MA
IQ;Ninawa;IQ-NI
IQ;Salah ad Din;IQ-SD
IQ;Wasit;IQ-WA
IR;Alborz;IR-30
IR;Ardabil;IR-24
IR;Azarbayjan-e Gharbi;IR-04
IR;Azarbayjan-e Sharqi;IR-03
IR;Bushehr;IR-18
IR;Chahar Mahal va Bakhtiari;IR-14
IR;Esfahan;IR-10
IR;Fars;IR-07
IR;Gilan;IR-01
IR;Golestan;IR-27
IR;Hamadan;IR-13
IR;Hormozgan;IR-22
IR;Ilam;IR-16
IR;Kerman;IR-08
IR;Kermanshah;IR-05
IR;Khorasan-e Jonubi;IR-29
IR;Khorasan-e Razavi;IR-09
IR;Khorasan-e Shomali;IR-28
IR;Khuzestan;IR-06
IR;Kohgiluyeh va Bowyer Ahmad;IR-17
IR;Kordestan;IR-12
IR;Lorestan;IR-15
IR;Markazi;IR-00
IR;Mazandaran;IR-02
IR;Qazvin;IR-26
IR;Qom;IR-25
IR;Semnan;IR-20
IR;Sistan va Baluchestan;IR-11
IR;Tehran;IR-23
IR;Yazd;IR-21
IR;Zanjan;IR-19
IS;Austurland;IS-7
IS;Hofudborgarsvaedi;IS-1
IS;Nordurland eystra;IS-6
IS;Nordurland vestra;IS-5
IS;Sudurland;IS-8
IS;Sudurnes;IS-2
IS;Vestfirdir;IS-4
IS;Vesturland;IS-3
IT;Abruzzo;IT-65
IT;Basilicata;IT-77
IT;Calabria;IT-78
IT;Campania;IT-72
IT;Emilia-Romagna;IT-45
IT;Friuli-Venezia Giulia;IT-36
IT;Lazio;IT-62
IT;Liguria;IT-42
IT;Lombardia;IT-25
IT;Marche;IT-57
IT;Molise;IT-67
IT;Piemonte;IT-21
IT;Puglia;IT-75
IT;Sardegna;IT-88
IT;Sicilia;IT-82
IT;Toscana;IT-52
IT;Trentino-Alto Adige;IT-32
IT;Umbria;IT-55
IT;Valle d'Aosta;IT-23
IT;Veneto;IT-34
JE;Jersey;-
JM;Clarendon;JM-13
JM;Hanover;JM-09
JM;Kingston;JM-01
JM;Manchester;JM-12
JM;Portland;JM-04
JM;Saint Andrew;JM-02
JM;Saint Ann;JM-06
JM;Saint Catherine;JM-14
JM;Saint Elizabeth;JM-11
JM;Saint James;JM-08
JM;Saint Mary;JM-05
JM;Saint Thomas;JM-03
JM;Trelawny;JM-07
JM;Westmoreland;JM-10
JO;'Ajlun;JO-AJ
JO;Al 'Aqabah;JO-AQ
JO;Al 'Asimah;JO-AM
JO;Al Balqa';JO-BA
JO;Al Karak;JO-KA
JO;Al Mafraq;JO-MA
JO;Az Zarqa';JO-AZ
JO;Irbid;JO-IR
JO;Jarash;JO-JA
JO;Ma'an;JO-MN
JO;Madaba;JO-MD
JP;Aichi;JP-23
JP;Akita;JP-05
JP;Aomori;JP-02
JP;Chiba;JP-12
JP;Ehime;JP-38
JP;Fukui;JP-18
JP;Fukuoka;JP-40
JP;Fukushima;JP-07
JP;Gifu;JP-21
JP;Gunma;JP-10
JP;Hiroshima;JP-34
JP;Hokkaido;JP-01
JP;Hyogo;JP-28
JP;Ibaraki;JP-08
JP;Ishikawa;JP-17
JP;Iwate;JP-03
JP;Kagawa;JP-37
JP;Kagoshima;JP-46
JP;Kanagawa;JP-14
JP;Kochi;JP-39
JP;Kumamoto;JP-43
JP;Kyoto;JP-26
JP;Mie;JP-24
JP;Miyagi;JP-04
JP;Miyazaki;JP-45
JP;Nagano;JP-20
JP;Nagasaki;JP-42
JP;Nara;JP-29
JP;Niigata;JP-15
JP;Oita;JP-44
JP;Okayama;JP-33
JP;Okinawa;JP-47
JP;Osaka;JP-27
JP;Saga;JP-41
JP;Saitama;JP-11
JP;Shiga;JP-25
JP;Shimane;JP-32
JP;Shizuoka;JP-22
JP;Tochigi;JP-09
JP;Tokushima;JP-36
JP;Tokyo;JP-13
JP;Tottori;JP-31
JP;Toyama;JP-16
JP;Wakayama;JP-30
JP;Yamagata;JP-06
JP;Yamaguchi;JP-35
JP;Yamanashi;JP-19
KE;Baringo;KE-01
KE;Bomet;KE-02
KE;Bungoma;KE-03
KE;Busia;KE-04
KE;Elgeyo/Marakwet;KE-05
KE;Embu;KE-06
KE;Garissa;KE-07
KE;Homa Bay;KE-08
KE;Isiolo;KE-09
KE;Kajiado;KE-10
KE;Kakamega;KE-11
KE;Kericho;KE-12
KE;Kiambu;KE-13
KE;Kilifi;KE-14
KE;Kirinyaga;KE-15
KE;Kisii;KE-16
KE;Kisumu;KE-17
KE;Kitui;KE-18
KE;Kwale;KE-19
KE;Laikipia;KE-20
KE;Lamu;KE-21
KE;Machakos;KE-22
KE;Makueni;KE-23
KE;Mandera;KE-24
KE;Marsabit;KE-25
KE;Meru;KE-26
KE;Migori;KE-27
KE;Mombasa;KE-28
KE;Murang'a;KE-29
KE;Nairobi City;KE-30
KE;Nakuru;KE-31
KE;Nandi;KE-32
KE;Narok;KE-33
KE;Nyamira;KE-34
KE;Nyandarua;KE-35
KE;Nyeri;KE-36
KE;Samburu;KE-37
KE;Siaya;KE-38
KE;Taita/Taveta;KE-39
KE;Tana River;KE-40
KE;Tharaka-Nithi;KE-41
KE;Trans Nzoia;KE-42
KE;Turkana;KE-43
KE;Uasin Gishu;KE-44
KE;Vihiga;KE-45
KE;Wajir;KE-46
KE;West Pokot;KE-47
KG;Batken;KG-B
KG;Bishkek Shaary;KG-GB
KG;Chuy;KG-C
KG;Jalal-Abad;KG-J
KG;Naryn;KG-N
KG;Osh Shaary;KG-GO
KG;Talas;KG-T
KG;Ysyk-Kol;KG-Y
KH;Baat Dambang;KH-2
KH;Banteay Mean Choay;KH-1
KH;Kaeb;KH-23
KH;Kampong Chaam;KH-3
KH;Kampong Chhnang;KH-4
KH;Kampong Spueu;KH-5
KH;Kampong Thum;KH-6
KH;Kampot;KH-7
KH;Kandaal;KH-8
KH;Kracheh;KH-10
KH;Mondol Kiri;KH-11
KH;Pailin;KH-24
KH;Phnom Penh;KH-12
KH;Pousaat;KH-15
KH;Preah Sihanouk;KH-18
KH;Prey Veaeng;KH-14
KH;Rotanak Kiri;KH-16
KH;Siem Reab;KH-17
KH;Stueng Traeng;KH-19
KH;Svaay Rieng;KH-20
KH;Taakaev;KH-21
KI;Gilbert Islands;KI-G
KI;Line Islands;KI-L
KM;Grande Comore;KM-G
KM;Moheli;KM-M
KN;Christ Church Nichola Town;KN-01
KN;Saint Anne Sandy Point;KN-02
KN;Saint George Basseterre;KN-03
KN;Saint James Windward;KN-05
KN;Saint John Capisterre;KN-06
KN;Saint John Figtree;KN-07
KN;Saint Mary Cayon;KN-08
KN;Saint Paul Capisterre;KN-09
KN;Saint Paul Charlestown;KN-10
KN;Saint Peter Basseterre;KN-11
KN;Saint Thomas Middle Island;KN-13
KN;Trinity Palmetto Point;KN-15
KP;P'yongyang;KP-01
KR;Busan-gwangyeoksi;KR-26
KR;Chungcheongbuk-do;KR-43
KR;Chungcheongnam-do;KR-44
KR;Daegu-gwangyeoksi;KR-27
KR;Daejeon-gwangyeoksi;KR-30
KR;Gangwon-do;KR-42
KR;Gwangju-gwangyeoksi;KR-29
KR;Gyeonggi-do;KR-41
KR;Gyeongsangbuk-do;KR-47
KR;Gyeongsangnam-do;KR-48
KR;Incheon-gwangyeoksi;KR-28
KR;Jeju-teukbyeoljachido;KR-49
KR;Jeollabuk-do;KR-45
KR;Jeollanam-do;KR-46
KR;Seoul-teukbyeolsi;KR-11
KR;Ulsan-gwangyeoksi;KR-31
KW;Al 'Asimah;KW-KU
KW;Al Ahmadi;KW-AH
KW;Al Farwaniyah;KW-FA
KW;Al Jahra';KW-JA
KW;Hawalli;KW-HA
KW;Mubarak al Kabir;KW-MU
KY;Cayman Islands;-
KZ;Almaty;KZ-ALA
KZ;Almaty oblysy;KZ-ALM
KZ;Aqmola oblysy;KZ-AKM
KZ;Aqtobe oblysy;KZ-AKT
KZ;Atyrau oblysy;KZ-ATY
KZ;Batys Qazaqstan oblysy;KZ-ZAP
KZ;Mangghystau oblysy;KZ-MAN
KZ;Nur-Sultan;KZ-AST
KZ;Ongtustik Qazaqstan oblysy;KZ-YUZ
KZ;Pavlodar oblysy;KZ-PAV
KZ;Qaraghandy oblysy;KZ-KAR
KZ;Qostanay oblysy;KZ-KUS
KZ;Qyzylorda oblysy;KZ-KZY
KZ;Shyghys Qazaqstan oblysy;KZ-VOS
KZ;Shymkent;KZ-SHY
KZ;Soltustik Qazaqstan oblysy;KZ-SEV
KZ;Zhambyl oblysy;KZ-ZHA
LA;Attapu;LA-AT
LA;Bokeo;LA-BK
LA;Bolikhamxai;LA-BL
LA;Champasak;LA-CH
LA;Houaphan;LA-HO
LA;Khammouan;LA-KH
LA;Louang Namtha;LA-LM
LA;Louangphabang;LA-LP
LA;Oudomxai;LA-OU
LA;Phongsali;LA-PH
LA;Savannakhet;LA-SV
LA;Viangchan;LA-VI
LA;Xaignabouli;LA-XA
LA;Xekong;LA-XE
LA;Xiangkhouang;LA-XI
LB;Aakkar;LB-AK
LB;Baalbek-Hermel;LB-BH
LB;Beqaa;LB-BI
LB;Beyrouth;LB-BA
LB;Liban-Nord;LB-AS
LB;Liban-Sud;LB-JA
LB;Mont-Liban;LB-JL
LB;Nabatiye;LB-NA
LC;Anse la Raye;LC-01
LC;Castries;LC-02
LC;Choiseul;LC-03
LC;Dennery;LC-05
LC;Gros Islet;LC-06
LC;Laborie;LC-07
LC;Micoud;LC-08
LC;Soufriere;LC-10
LC;Vieux Fort;LC-11
LI;Balzers;LI-01
LI;Eschen;LI-02
LI;Gamprin;LI-03
LI;Mauren;LI-04
LI;Planken;LI-05
LI;Ruggell;LI-06
LI;Schaan;LI-07
LI;Triesen;LI-09
LI;Triesenberg;LI-10
LI;Vaduz;LI-11
LK;Central Province;LK-2
LK;Eastern Province;LK-5
LK;North Central Province;LK-7
LK;North Western Province;LK-6
LK;Northern Province;LK-4
LK;Sabaragamuwa Province;LK-9
LK;Southern Province;LK-3
LK;Uva Province;LK-8
LK;Western Province;LK-1
LR;Bomi;LR-BM
LR;Grand Bassa;LR-GB
LR;Grand Gedeh;LR-GG
LR;Margibi;LR-MG
LR;Montserrado;LR-MO
LR;Nimba;LR-NI
LR;River Cess;LR-RI
LR;Sinoe;LR-SI
LS;Berea;LS-D
LS;Botha-Bothe;LS-B
LS;Leribe;LS-C
LS;Mafeteng;LS-E
LS;Maseru;LS-A
LS;Mohale's Hoek;LS-F
LS;Mokhotlong;LS-J
LS;Qacha's Nek;LS-H
LS;Quthing;LS-G
LS;Thaba-Tseka;LS-K
LT;Alytaus apskritis;LT-AL
LT;Kauno apskritis;LT-KU
LT;Klaipedos apskritis;LT-KL
LT;Marijampoles apskritis;LT-MR
LT;Panevezio apskritis;LT-PN
LT;Siauliu apskritis;LT-SA
LT;Taurages apskritis;LT-TA
LT;Telsiu apskritis;LT-TE
LT;Utenos apskritis;LT-UT
LT;Vilniaus apskritis;LT-VL
LU;Capellen;LU-CA
LU;Clervaux;LU-CL
LU;Diekirch;LU-DI
LU;Echternach;LU-EC
LU;Esch-sur-Alzette;LU-ES
LU;Grevenmacher;LU-GR
LU;Luxembourg;LU-LU
LU;Mersch;LU-ME
LU;Redange;LU-RD
LU;Remich;LU-RM
LU;Vianden;LU-VD
LU;Wiltz;LU-WI
LV;Adazu novads;LV-011
LV;Aizkraukles novads;LV-002
LV;Aluksnes novads;LV-007
LV;Augsdaugavas novads;LV-111
LV;Balvu novads;LV-015
LV;Bauskas novads;LV-016
LV;Cesu novads;LV-022
LV;Daugavpils;LV-DGV
LV;Dienvidkurzemes novads;LV-112
LV;Dobeles novads;LV-026
LV;Gulbenes novads;LV-033
LV;Jekabpils novads;LV-042
LV;Jelgava;LV-JEL
LV;Jelgavas novads;LV-041
LV;Jurmala;LV-JUR
LV;Kekavas novads;LV-052
LV;Kraslavas novads;LV-047
LV;Kuldigas novads;LV-050
LV;Liepaja;LV-LPX
LV;Limbazu novads;LV-054
LV;Livanu novads;LV-056
LV;Ludzas novads;LV-058
LV;Madonas novads;LV-059
LV;Marupes novads;LV-062
LV;Ogres novads;LV-067
LV;Olaines novads;LV-068
LV;Preilu novads;LV-073
LV;Rezeknes novads;LV-077
LV;Riga;LV-RIX
LV;Ropazu novads;LV-080
LV;Salaspils novads;LV-087
LV;Saldus novads;LV-088
LV;Saulkrastu novads;LV-089
LV;Siguldas novads;LV-091
LV;Smiltenes novads;LV-094
LV;Talsu novads;LV-097
LV;Tukuma novads;LV-099
LV;Valkas novads;LV-101
LV;Valmieras novads;LV-113
LV;Varaklanu novads;LV-102
LV;Ventspils novads;LV-106
LY;Al Butnan;LY-BU
LY;Al Jabal al Akhdar;LY-JA
LY;Al Jabal al Gharbi;LY-JG
LY;Al Jafarah;LY-JI
LY;Al Jufrah;LY-JU
LY;Al Kufrah;LY-KF
LY;Al Marj;LY-MJ
LY;Al Marqab;LY-MB
LY;Al Wahat;LY-WA
LY;An Nuqat al Khams;LY-NQ
LY;Az Zawiyah;LY-ZA
LY;Banghazi;LY-BA
LY;Darnah;LY-DR
LY;Misratah;LY-MI
LY;Murzuq;LY-MQ
LY;Nalut;LY-NL
LY;Sabha;LY-SB
LY;Surt;LY-SR
LY;Tarabulus;LY-TB
LY;Wadi ash Shati';LY-WS
MA;Beni-Mellal-Khenifra;MA-05
MA;Casablanca-Settat;MA-06
MA;Draa-Tafilalet;MA-08
MA;Fes- Meknes;MA-03
MA;Guelmim-Oued Noun (EH-partial);MA-10
MA;L'Oriental;MA-02
MA;Laayoune-Sakia El Hamra (EH-partial);MA-11
MA;Marrakech-Safi;MA-07
MA;Rabat-Sale-Kenitra;MA-04
MA;Souss-Massa;MA-09
MA;Tanger-Tetouan-Al Hoceima;MA-01
MC;Fontvieille;MC-FO
MC;La Condamine;MC-CO
MC;Monaco-Ville;MC-MO
MC;Moneghetti;MC-MG
MC;Monte-Carlo;MC-MC
MC;Saint-Roman;MC-SR
MD;Anenii Noi;MD-AN
MD;Balti;MD-BA
MD;Basarabeasca;MD-BS
MD;Bender;MD-BD
MD;Briceni;MD-BR
MD;Cahul;MD-CA
MD;Calarasi;MD-CL
MD;Cantemir;MD-CT
MD;Causeni;MD-CS
MD;Chisinau;MD-CU
MD;Cimislia;MD-CM
MD;Criuleni;MD-CR
MD;Donduseni;MD-DO
MD;Drochia;MD-DR
MD;Dubasari;MD-DU
MD;Edinet;MD-ED
MD;Falesti;MD-FA
MD;Floresti;MD-FL
MD;Gagauzia, Unitatea teritoriala autonoma;MD-GA
MD;Glodeni;MD-GL
MD;Hincesti;MD-HI
MD;Ialoveni;MD-IA
MD;Leova;MD-LE
MD;Nisporeni;MD-NI
MD;Ocnita;MD-OC
MD;Orhei;MD-OR
MD;Rezina;MD-RE
MD;Riscani;MD-RI
MD;Singerei;MD-SI
MD;Soldanesti;MD-SD
MD;Soroca;MD-SO
MD;Stefan Voda;MD-SV
MD;Stinga Nistrului, unitatea teritoriala din;MD-SN
MD;Straseni;MD-ST
MD;Taraclia;MD-TA
MD;Telenesti;MD-TE
MD;Ungheni;MD-UN
ME;Andrijevica;ME-01
ME;Bar;ME-02
ME;Berane;ME-03
ME;Bijelo Polje;ME-04
ME;Budva;ME-05
ME;Cetinje;ME-06
ME;Danilovgrad;ME-07
ME;Herceg-Novi;ME-08
ME;Kolasin;ME-09
ME;Kotor;ME-10
ME;Niksic;ME-12
ME;Plav;ME-13
ME;Pljevlja;ME-14
ME;Pluzine;ME-15
ME;Podgorica;ME-16
ME;Rozaje;ME-17
ME;Tivat;ME-19
ME;Tuzi;ME-24
ME;Ulcinj;ME-20
ME;Zabljak;ME-21
MF;Saint Martin (French Part);-
MG;Antananarivo;MG-T
MG;Antsiranana;MG-D
MG;Fianarantsoa;MG-F
MG;Mahajanga;MG-M
MG;Toamasina;MG-A
MG;Toliara;MG-U
MH;Kwajalein;MH-KWA
MH;Majuro;MH-MAJ
MK;Berovo;MK-201
MK;Bitola;MK-501
MK;Bogdanci;MK-401
MK;Bogovinje;MK-601
MK;Bosilovo;MK-402
MK;Brvenica;MK-602
MK;Butel;MK-803
MK;Caska;MK-109
MK;Centar;MK-814
MK;Cesinovo-Oblesevo;MK-210
MK;Cucer Sandevo;MK-816
MK;Debar;MK-303
MK;Demir Hisar;MK-502
MK;Demir Kapija;MK-103
MK;Dojran;MK-406
MK;Dolneni;MK-503
MK;Gazi Baba;MK-804
MK;Gevgelija;MK-405
MK;Gostivar;MK-604
MK;Gradsko;MK-102
MK;Ilinden;MK-807
MK;Jegunovce;MK-606
MK;Karbinci;MK-205
MK;Kavadarci;MK-104
MK;Kicevo;MK-307
MK;Kisela Voda;MK-809
MK;Kocani;MK-206
MK;Kratovo;MK-701
MK;Kriva Palanka;MK-702
MK;Krusevo;MK-505
MK;Kumanovo;MK-703
MK;Lipkovo;MK-704
MK;Lozovo;MK-105
MK;Makedonska Kamenica;MK-207
MK;Makedonski Brod;MK-308
MK;Mavrovo i Rostusa;MK-607
MK;Mogila;MK-506
MK;Negotino;MK-106
MK;Novaci;MK-507
MK;Novo Selo;MK-408
MK;Ohrid;MK-310
MK;Pehcevo;MK-208
MK;Petrovec;MK-810
MK;Plasnica;MK-311
MK;Prilep;MK-508
MK;Probistip;MK-209
MK;Radovis;MK-409
MK;Rankovce;MK-705
MK;Resen;MK-509
MK;Rosoman;MK-107
MK;Saraj;MK-811
MK;Sopiste;MK-812
MK;Stip;MK-211
MK;Struga;MK-312
MK;Strumica;MK-410
MK;Studenicani;MK-813
MK;Sveti Nikole;MK-108
MK;Tearce;MK-608
MK;Tetovo;MK-609
MK;Valandovo;MK-403
MK;Vasilevo;MK-404
MK;Veles;MK-101
MK;Vevcani;MK-301
MK;Vinica;MK-202
MK;Zelenikovo;MK-806
MK;Zelino;MK-605
ML;Bamako;ML-BKO
ML;Gao;ML-7
ML;Kayes;ML-1
ML;Kidal;ML-8
ML;Koulikoro;ML-2
ML;Mopti;ML-5
ML;Segou;ML-4
ML;Sikasso;ML-3
ML;Tombouctou;ML-6
MM;Ayeyarwady;MM-07
MM;Bago;MM-02
MM;Kachin;MM-11
MM;Kayin;MM-13
MM;Magway;MM-03
MM;Mandalay;MM-04
MM;Mon;MM-15
MM;Nay Pyi Taw;MM-18
MM;Rakhine;MM-16
MM;Sagaing;MM-01
MM;Shan;MM-17
MM;Tanintharyi;MM-05
MM;Yangon;MM-06
MN;Bayan-Olgiy;MN-071
MN;Dornod;MN-061
MN;Govi-Altay;MN-065
MN;Hovd;MN-043
MN;Orhon;MN-035
MN;Ovorhangay;MN-055
MN;Selenge;MN-049
MN;Tov;MN-047
MN;Ulaanbaatar;MN-1
MO;Macao;-
MP;Northern Mariana Islands;-
MQ;Martinique;-
MR;Adrar;MR-07
MR;Assaba;MR-03
MR;Brakna;MR-05
MR;Dakhlet Nouadhibou;MR-08
MR;Gorgol;MR-04
MR;Hodh ech Chargui;MR-01
MR;Hodh el Gharbi;MR-02
MR;Inchiri;MR-12
MR;Nouakchott Ouest;MR-13
MR;Tagant;MR-09
MR;Tiris Zemmour;MR-11
MR;Trarza;MR-06
MS;Saint Anthony;-
MS;Saint Peter;-
MT;Attard;MT-01
MT;Balzan;MT-02
MT;Birgu;MT-03
MT;Birkirkara;MT-04
MT;Birzebbuga;MT-05
MT;Bormla;MT-06
MT;Dingli;MT-07
MT;Fgura;MT-08
MT;Floriana;MT-09
MT;Fontana;MT-10
MT;Gharb;MT-14
MT;Gharghur;MT-15
MT;Ghasri;MT-16
MT;Ghaxaq;MT-17
MT;Gudja;MT-11
MT;Gzira;MT-12
MT;Hamrun;MT-18
MT;Iklin;MT-19
MT;Isla;MT-20
MT;Kalkara;MT-21
MT;Kercem;MT-22
MT;Kirkop;MT-23
MT;Lija;MT-24
MT;Luqa;MT-25
MT;Marsa;MT-26
MT;Marsaskala;MT-27
MT;Marsaxlokk;MT-28
MT;Mdina;MT-29
MT;Mellieha;MT-30
MT;Mgarr;MT-31
MT;Mosta;MT-32
MT;Mqabba;MT-33
MT;Msida;MT-34
MT;Mtarfa;MT-35
MT;Munxar;MT-36
MT;Nadur;MT-37
MT;Naxxar;MT-38
MT;Paola;MT-39
MT;Pembroke;MT-40
MT;Pieta;MT-41
MT;Qala;MT-42
MT;Qormi;MT-43
MT;Rabat Gozo;MT-45
MT;Rabat Malta;MT-46
MT;Safi;MT-47
MT;Saint John;MT-49
MT;Saint Julian's;MT-48
MT;Saint Lucia's;MT-53
MT;Saint Paul's Bay;MT-51
MT;Sannat;MT-52
MT;Santa Venera;MT-54
MT;Siggiewi;MT-55
MT;Sliema;MT-56
MT;Swieqi;MT-57
MT;Ta' Xbiex;MT-58
MT;Tarxien;MT-59
MT;Valletta;MT-60
MT;Xaghra;MT-61
MT;Xewkija;MT-62
MT;Xghajra;MT-63
MT;Zabbar;MT-64
MT;Zebbug Gozo;MT-65
MT;Zejtun;MT-67
MT;Zurrieq;MT-68
MU;Black River;MU-BL
MU;Flacq;MU-FL
MU;Grand Port;MU-GP
MU;Moka;MU-MO
MU;Pamplemousses;MU-PA
MU;Plaines Wilhems;MU-PW
MU;Port Louis;MU-PL
MU;Riviere du Rempart;MU-RR
MU;Rodrigues Islands;MU-RO
MU;Savanne;MU-SA
MV;Addu City;MV-01
MV;Faadhippolhu;MV-03
MV;Felidhu Atoll;MV-04
MV;Hahdhunmathi;MV-05
MV;Male;MV-MLE
MV;Mulaku Atoll;MV-12
MV;North Maalhosmadulu;MV-13
MV;South Ari Atoll;MV-00
MV;South Huvadhu Atoll;MV-28
MV;South Maalhosmadulu;MV-20
MV;South Miladhunmadulu;MV-25
MV;South Nilandhe Atoll;MV-17
MV;South Thiladhunmathi;MV-23
MW;Balaka;MW-BA
MW;Blantyre;MW-BL
MW;Chikwawa;MW-CK
MW;Chiradzulu;MW-CR
MW;Dedza;MW-DE
MW;Dowa;MW-DO
MW;Karonga;MW-KR
MW;Lilongwe;MW-LI
MW;Machinga;MW-MH
MW;Mangochi;MW-MG
MW;Mchinji;MW-MC
MW;Mwanza;MW-MW
MW;Mzimba;MW-MZ
MW;Neno;MW-NE
MW;Nkhotakota;MW-NK
MW;Ntchisi;MW-NI
MW;Salima;MW-SA
MW;Thyolo;MW-TH
MW;Zomba;MW-ZO
MX;Aguascalientes;MX-AGU
MX;Baja California;MX-BCN
MX;Baja California Sur;MX-BCS
MX;Campeche;MX-CAM
MX;Chiapas;MX-CHP
MX;Chihuahua;MX-CHH
MX;Ciudad de Mexico;MX-CMX
MX;Coahuila de Zaragoza;MX-COA
MX;Colima;MX-COL
MX;Durango;MX-DUR
MX;Guanajuato;MX-GUA
MX;Guerrero;MX-GRO
MX;Hidalgo;MX-HID
MX;Jalisco;MX-JAL
MX;Mexico;MX-MEX
MX;Michoacan de Ocampo;MX-MIC
MX;Morelos;MX-MOR
MX;Nayarit;MX-NAY
MX;Nuevo Leon;MX-NLE
MX;Oaxaca;MX-OAX
MX;Puebla;MX-PUE
MX;Queretaro;MX-QUE
MX;Quintana Roo;MX-ROO
MX;San Luis Potosi;MX-SLP
MX;Sinaloa;MX-SIN
MX;Sonora;MX-SON
MX;Tabasco;MX-TAB
MX;Tamaulipas;MX-TAM
MX;Tlaxcala;MX-TLA
MX;Veracruz de Ignacio de la Llave;MX-VER
MX;Yucatan;MX-YUC
MX;Zacatecas;MX-ZAC
MY;Johor;MY-01
MY;Kedah;MY-02
MY;Kelantan;MY-03
MY;Melaka;MY-04
MY;Negeri Sembilan;MY-05
MY;Pahang;MY-06
MY;Perak;MY-08
MY;Perlis;MY-09
MY;Pulau Pinang;MY-07
MY;Sabah;MY-12
MY;Sarawak;MY-13
MY;Selangor;MY-10
MY;Terengganu;MY-11
MY;Wilayah Persekutuan Kuala Lumpur;MY-14
MY;Wilayah Persekutuan Labuan;MY-15
MY;Wilayah Persekutuan Putrajaya;MY-16
MZ;Cabo Delgado;MZ-P
MZ;Gaza;MZ-G
MZ;Inhambane;MZ-I
MZ;Manica;MZ-B
MZ;Maputo;MZ-L
MZ;Nampula;MZ-N
MZ;Niassa;MZ-A
MZ;Sofala;MZ-S
MZ;Tete;MZ-T
MZ;Zambezia;MZ-Q
NA;Erongo;NA-ER
NA;Hardap;NA-HA
NA;Karas;NA-KA
NA;Kavango East;NA-KE
NA;Kavango West;NA-KW
NA;Khomas;NA-KH
NA;Kunene;NA-KU
NA;Ohangwena;NA-OW
NA;Omaheke;NA-OH
NA;Omusati;NA-OS
NA;Oshana;NA-ON
NA;Oshikoto;NA-OT
NA;Otjozondjupa;NA-OD
NA;Zambezi;NA-CA
NC;Province Nord;-
NC;Province Sud;-
NE;Agadez;NE-1
NE;Diffa;NE-2
NE;Dosso;NE-3
NE;Maradi;NE-4
NE;Niamey;NE-8
NE;Tahoua;NE-5
NE;Tillaberi;NE-6
NE;Zinder;NE-7
NF;Norfolk Island;-
NG;Abia;NG-AB
NG;Abuja Federal Capital Territory;NG-FC
NG;Adamawa;NG-AD
NG;Akwa Ibom;NG-AK
NG;Anambra;NG-AN
NG;Bauchi;NG-BA
NG;Bayelsa;NG-BY
NG;Benue;NG-BE
NG;Borno;NG-BO
NG;Cross River;NG-CR
NG;Delta;NG-DE
NG;Ebonyi;NG-EB
NG;Edo;NG-ED
NG;Ekiti;NG-EK
NG;Enugu;NG-EN
NG;Gombe;NG-GO
NG;Imo;NG-IM
NG;Jigawa;NG-JI
NG;Kaduna;NG-KD
NG;Kano;NG-KN
NG;Katsina;NG-KT
NG;Kebbi;NG-KE
NG;Kogi;NG-KO
NG;Kwara;NG-KW
NG;Lagos;NG-LA
NG;Nasarawa;NG-NA
NG;Niger;NG-NI
NG;Ogun;NG-OG
NG;Ondo;NG-ON
NG;Osun;NG-OS
NG;Oyo;NG-OY
NG;Plateau;NG-PL
NG;Rivers;NG-RI
NG;Sokoto;NG-SO
NG;Taraba;NG-TA
NG;Yobe;NG-YO
NG;Zamfara;NG-ZA
NI;Boaco;NI-BO
NI;Carazo;NI-CA
NI;Chinandega;NI-CI
NI;Chontales;NI-CO
NI;Costa Caribe Norte;NI-AN
NI;Costa Caribe Sur;NI-AS
NI;Esteli;NI-ES
NI;Granada;NI-GR
NI;Jinotega;NI-JI
NI;Leon;NI-LE
NI;Madriz;NI-MD
NI;Managua;NI-MN
NI;Masaya;NI-MS
NI;Matagalpa;NI-MT
NI;Nueva Segovia;NI-NS
NI;Rio San Juan;NI-SJ
NI;Rivas;NI-RI
NL;Drenthe;NL-DR
NL;Flevoland;NL-FL
NL;Fryslan;NL-FR
NL;Gelderland;NL-GE
NL;Groningen;NL-GR
NL;Limburg;NL-LI
NL;Noord-Brabant;NL-NB
NL;Noord-Holland;NL-NH
NL;Overijssel;NL-OV
NL;Utrecht;NL-UT
NL;Zeeland;NL-ZE
NL;Zuid-Holland;NL-ZH
NO;Agder;NO-42
NO;Innlandet;NO-34
NO;More og Romsdal;NO-15
NO;Nordland;NO-18
NO;Oslo;NO-03
NO;Rogaland;NO-11
NO;Troms og Finnmark;NO-54
NO;Trondelag;NO-50
NO;Vestfold og Telemark;NO-38
NO;Vestland;NO-46
NO;Viken;NO-30
NP;Bagmati;NP-BA
NP;Bheri;NP-BH
NP;Dhawalagiri;NP-DH
NP;Gandaki;NP-GA
NP;Janakpur;NP-JA
NP;Karnali;NP-KA
NP;Kosi;NP-KO
NP;Lumbini;NP-LU
NP;Mahakali;NP-MA
NP;Mechi;NP-ME
NP;Narayani;NP-NA
NP;Rapti;NP-RA
NP;Sagarmatha;NP-SA
NP;Seti;NP-SE
NR;Aiwo;NR-01
NR;Anetan;NR-03
NR;Yaren;NR-14
NU;Niue;-
NZ;Auckland;NZ-AUK
NZ;Bay of Plenty;NZ-BOP
NZ;Canterbury;NZ-CAN
NZ;Chatham Islands Territory;NZ-CIT
NZ;Gisborne;NZ-GIS
NZ;Hawke's Bay;NZ-HKB
NZ;Manawatu-Wanganui;NZ-MWT
NZ;Marlborough;NZ-MBH
NZ;Nelson;NZ-NSN
NZ;Northland;NZ-NTL
NZ;Otago;NZ-OTA
NZ;Southland;NZ-STL
NZ;Taranaki;NZ-TKI
NZ;Tasman;NZ-TAS
NZ;Waikato;NZ-WKO
NZ;Wellington;NZ-WGN
NZ;West Coast;NZ-WTC
OM;Ad Dakhiliyah;OM-DA
OM;Al Buraymi;OM-BU
OM;Al Wusta;OM-WU
OM;Az Zahirah;OM-ZA
OM;Janub al Batinah;OM-BJ
OM;Janub ash Sharqiyah;OM-SJ
OM;Masqat;OM-MA
OM;Musandam;OM-MU
OM;Shamal al Batinah;OM-BS
OM;Shamal ash Sharqiyah;OM-SS
OM;Zufar;OM-ZU
PA;Bocas del Toro;PA-1
PA;Chiriqui;PA-4
PA;Cocle;PA-2
PA;Colon;PA-3
PA;Darien;PA-5
PA;Guna Yala;PA-KY
PA;Herrera;PA-6
PA;Los Santos;PA-7
PA;Ngobe-Bugle;PA-NB
PA;Panama;PA-8
PA;Veraguas;PA-9
PE;Amazonas;PE-AMA
PE;Ancash;PE-ANC
PE;Apurimac;PE-APU
PE;Arequipa;PE-ARE
PE;Ayacucho;PE-AYA
PE;Cajamarca;PE-CAJ
PE;Cusco;PE-CUS
PE;El Callao;PE-CAL
PE;Huancavelica;PE-HUV
PE;Huanuco;PE-HUC
PE;Ica;PE-ICA
PE;Junin;PE-JUN
PE;La Libertad;PE-LAL
PE;Lambayeque;PE-LAM
PE;Lima;PE-LIM
PE;Loreto;PE-LOR
PE;Madre de Dios;PE-MDD
PE;Moquegua;PE-MOQ
PE;Pasco;PE-PAS
PE;Piura;PE-PIU
PE;Puno;PE-PUN
PE;San Martin;PE-SAM
PE;Tacna;PE-TAC
PE;Tumbes;PE-TUM
PE;Ucayali;PE-UCA
PF;Iles Australes;-
PF;Iles Marquises;-
PF;Iles Sous-le-Vent;-
PF;Iles Tuamotu-Gambier;-
PF;Iles du Vent;-
PG;Bougainville;PG-NSB
PG;Central;PG-CPM
PG;Chimbu;PG-CPK
PG;East New Britain;PG-EBR
PG;East Sepik;PG-ESW
PG;Eastern Highlands;PG-EHG
PG;Madang;PG-MPM
PG;Manus;PG-MRL
PG;Milne Bay;PG-MBA
PG;Morobe;PG-MPL
PG;National Capital District (Port Moresby);PG-NCD
PG;New Ireland;PG-NIK
PG;Southern Highlands;PG-SHM
PG;West New Britain;PG-WBK
PG;West Sepik;PG-SAN
PG;Western;PG-WPD
PG;Western Highlands;PG-WHM
PH;Abra;PH-ABR
PH;Agusan del Norte;PH-AGN
PH;Agusan del Sur;PH-AGS
PH;Aklan;PH-AKL
PH;Albay;PH-ALB
PH;Antique;PH-ANT
PH;Apayao;PH-APA
PH;Aurora;PH-AUR
PH;Basilan;PH-BAS
PH;Bataan;PH-BAN
PH;Batanes;PH-BTN
PH;Batangas;PH-BTG
PH;Benguet;PH-BEN
PH;Biliran;PH-BIL
PH;Bohol;PH-BOH
PH;Bukidnon;PH-BUK
PH;Bulacan;PH-BUL
PH;Cagayan;PH-CAG
PH;Camarines Norte;PH-CAN
PH;Camarines Sur;PH-CAS
PH;Camiguin;PH-CAM
PH;Capiz;PH-CAP
PH;Catanduanes;PH-CAT
PH;Cavite;PH-CAV
PH;Cebu;PH-CEB
PH;Cotabato;PH-NCO
PH;Davao Oriental;PH-DAO
PH;Davao de Oro;PH-COM
PH;Davao del Norte;PH-DAV
PH;Davao del Sur;PH-DAS
PH;Dinagat Islands;PH-DIN
PH;Eastern Samar;PH-EAS
PH;Guimaras;PH-GUI
PH;Ifugao;PH-IFU
PH;Ilocos Norte;PH-ILN
PH;Ilocos Sur;PH-ILS
PH;Iloilo;PH-ILI
PH;Isabela;PH-ISA
PH;Kalinga;PH-KAL
PH;La Union;PH-LUN
PH;Laguna;PH-LAG
PH;Lanao del Norte;PH-LAN
PH;Lanao del Sur;PH-LAS
PH;Leyte;PH-LEY
PH;Maguindanao;PH-MAG
PH;Marinduque;PH-MAD
PH;Masbate;PH-MAS
PH;Mindoro Occidental;PH-MDC
PH;Mindoro Oriental;PH-MDR
PH;Misamis Occidental;PH-MSC
PH;Misamis Oriental;PH-MSR
PH;Mountain Province;PH-MOU
PH;National Capital Region;PH-00
PH;Negros Occidental;PH-NEC
PH;Negros Oriental;PH-NER
PH;Northern Samar;PH-NSA
PH;Nueva Ecija;PH-NUE
PH;Nueva Vizcaya;PH-NUV
PH;Palawan;PH-PLW
PH;Pampanga;PH-PAM
PH;Pangasinan;PH-PAN
PH;Quezon;PH-QUE
PH;Quirino;PH-QUI
PH;Rizal;PH-RIZ
PH;Romblon;PH-ROM
PH;Samar;PH-WSA
PH;Sarangani;PH-SAR
PH;Siquijor;PH-SIG
PH;Sorsogon;PH-SOR
PH;South Cotabato;PH-SCO
PH;Southern Leyte;PH-SLE
PH;Sultan Kudarat;PH-SUK
PH;Sulu;PH-SLU
PH;Surigao del Norte;PH-SUN
PH;Surigao del Sur;PH-SUR
PH;Tarlac;PH-TAR
PH;Tawi-Tawi;PH-TAW
PH;Zambales;PH-ZMB
PH;Zamboanga Sibugay;PH-ZSI
PH;Zamboanga del Norte;PH-ZAN
PH;Zamboanga del Sur;PH-ZAS
PK;Azad Jammu and Kashmir;PK-JK
PK;Balochistan;PK-BA
PK;Gilgit-Baltistan;PK-GB
PK;Islamabad;PK-IS
PK;Khyber Pakhtunkhwa;PK-KP
PK;Punjab;PK-PB
PK;Sindh;PK-SD
PL;Dolnoslaskie;PL-02
PL;Kujawsko-pomorskie;PL-04
PL;Lodzkie;PL-10
PL;Lubelskie;PL-06
PL;Lubuskie;PL-08
PL;Malopolskie;PL-12
PL;Mazowieckie;PL-14
PL;Opolskie;PL-16
PL;Podkarpackie;PL-18
PL;Podlaskie;PL-20
PL;Pomorskie;PL-22
PL;Slaskie;PL-24
PL;Swietokrzyskie;PL-26
PL;Warminsko-mazurskie;PL-28
PL;Wielkopolskie;PL-30
PL;Zachodniopomorskie;PL-32
PM;Saint Pierre and Miquelon;-
PN;Pitcairn;-
PR;Adjuntas;-
PR;Aguada;-
PR;Aguadilla;-
PR;Aguas Buenas;-
PR;Aibonito;-
PR;Anasco;-
PR;Arecibo;-
PR;Arroyo;-
PR;Barceloneta;-
PR;Barranquitas;-
PR;Bayamon;-
PR;Cabo Rojo;-
PR;Caguas;-
PR;Camuy;-
PR;Canovanas;-
PR;Carolina;-
PR;Catano;-
PR;Cayey;-
PR;Ceiba;-
PR;Ciales;-
PR;Cidra;-
PR;Coamo;-
PR;Comerio;-
PR;Corozal;-
PR;Culebra;-
PR;Dorado;-
PR;Fajardo;-
PR;Florida;-
PR;Guanica;-
PR;Guayama;-
PR;Guayanilla;-
PR;Guaynabo;-
PR;Gurabo;-
PR;Hatillo;-
PR;Hormigueros;-
PR;Humacao;-
PR;Isabela;-
PR;Juana Diaz;-
PR;Lajas;-
PR;Lares;-
PR;Las Marias;-
PR;Las Piedras;-
PR;Loiza;-
PR;Luquillo;-
PR;Manati;-
PR;Maunabo;-
PR;Mayaguez;-
PR;Moca;-
PR;Morovis;-
PR;Municipio de Jayuya;-
PR;Municipio de Juncos;-
PR;Naguabo;-
PR;Naranjito;-
PR;Patillas;-
PR;Penuelas;-
PR;Ponce;-
PR;Quebradillas;-
PR;Rincon;-
PR;Rio Grande;-
PR;Sabana Grande;-
PR;Salinas;-
PR;San German;-
PR;San Juan;-
PR;San Lorenzo;-
PR;San Sebastian;-
PR;Santa Isabel Municipio;-
PR;Toa Alta;-
PR;Toa Baja;-
PR;Trujillo Alto;-
PR;Utuado;-
PR;Vega Alta;-
PR;Vega Baja;-
PR;Vieques;-
PR;Villalba;-
PR;Yabucoa;-
PR;Yauco;-
PS;Bethlehem;PS-BTH
PS;Deir El Balah;PS-DEB
PS;Gaza;PS-GZA
PS;Hebron;PS-HBN
PS;Jenin;PS-JEN
PS;Jericho and Al Aghwar;PS-JRH
PS;Jerusalem;PS-JEM
PS;Khan Yunis;PS-KYS
PS;Nablus;PS-NBS
PS;Qalqilya;PS-QQA
PS;Rafah;PS-RFH
PS;Ramallah;PS-RBH
PS;Salfit;PS-SLT
PS;Tubas;PS-TBS
PS;Tulkarm;PS-TKM
PT;Aveiro;PT-01
PT;Beja;PT-02
PT;Braga;PT-03
PT;Braganca;PT-04
PT;Castelo Branco;PT-05
PT;Coimbra;PT-06
PT;Evora;PT-07
PT;Faro;PT-08
PT;Guarda;PT-09
PT;Leiria;PT-10
PT;Lisboa;PT-11
PT;Portalegre;PT-12
PT;Porto;PT-13
PT;Regiao Autonoma da Madeira;PT-30
PT;Regiao Autonoma dos Acores;PT-20
PT;Santarem;PT-14
PT;Setubal;PT-15
PT;Viana do Castelo;PT-16
PT;Vila Real;PT-17
PT;Viseu;PT-18
PW;Airai;PW-004
PW;Kayangel;PW-100
PW;Koror;PW-150
PW;Melekeok;PW-212
PW;Ngardmau;PW-222
PY;Alto Parana;PY-10
PY;Amambay;PY-13
PY;Asuncion;PY-ASU
PY;Boqueron;PY-19
PY;Caaguazu;PY-5
PY;Caazapa;PY-6
PY;Canindeyu;PY-14
PY;Central;PY-11
PY;Concepcion;PY-1
PY;Cordillera;PY-3
PY;Guaira;PY-4
PY;Itapua;PY-7
PY;Misiones;PY-8
PY;Neembucu;PY-12
PY;Paraguari;PY-9
PY;Presidente Hayes;PY-15
PY;San Pedro;PY-2
QA;Ad Dawhah;QA-DA
QA;Al Khawr wa adh Dhakhirah;QA-KH
QA;Al Wakrah;QA-WA
QA;Ar Rayyan;QA-RA
QA;Ash Shamal;QA-MS
QA;Az Za'ayin;QA-ZA
QA;Umm Salal;QA-US
RE;Reunion;-
RO;Alba;RO-AB
RO;Arad;RO-AR
RO;Arges;RO-AG
RO;Bacau;RO-BC
RO;Bihor;RO-BH
RO;Bistrita-Nasaud;RO-BN
RO;Botosani;RO-BT
RO;Braila;RO-BR
RO;Brasov;RO-BV
RO;Bucuresti;RO-B
RO;Buzau;RO-BZ
RO;Calarasi;RO-CL
RO;Caras-Severin;RO-CS
RO;Cluj;RO-CJ
RO;Constanta;RO-CT
RO;Covasna;RO-CV
RO;Dambovita;RO-DB
RO;Dolj;RO-DJ
RO;Galati;RO-GL
RO;Giurgiu;RO-GR
RO;Gorj;RO-GJ
RO;Harghita;RO-HR
RO;Hunedoara;RO-HD
RO;Ialomita;RO-IL
RO;Iasi;RO-IS
RO;Ilfov;RO-IF
RO;Maramures;RO-MM
RO;Mehedinti;RO-MH
RO;Mures;RO-MS
RO;Neamt;RO-NT
RO;Olt;RO-OT
RO;Prahova;RO-PH
RO;Salaj;RO-SJ
RO;Satu Mare;RO-SM
RO;Sibiu;RO-SB
RO;Suceava;RO-SV
RO;Teleorman;RO-TR
RO;Timis;RO-TM
RO;Tulcea;RO-TL
RO;Valcea;RO-VL
RO;Vaslui;RO-VS
RO;Vrancea;RO-VN
RS;Beograd;RS-00
RS;Borski okrug;RS-14
RS;Branicevski okrug;RS-11
RS;Jablanicki okrug;RS-23
RS;Juznobacki okrug;RS-06
RS;Juznobanatski okrug;RS-04
RS;Kolubarski okrug;RS-09
RS;Kosovsko-Mitrovacki okrug;RS-28
RS;Macvanski okrug;RS-08
RS;Moravicki okrug;RS-17
RS;Nisavski okrug;RS-20
RS;Pcinjski okrug;RS-24
RS;Pecki okrug;RS-26
RS;Pirotski okrug;RS-22
RS;Podunavski okrug;RS-10
RS;Pomoravski okrug;RS-13
RS;Prizrenski okrug;RS-27
RS;Rasinski okrug;RS-19
RS;Raski okrug;RS-18
RS;Severnobacki okrug;RS-01
RS;Severnobanatski okrug;RS-03
RS;Srednjebanatski okrug;RS-02
RS;Sremski okrug;RS-07
RS;Sumadijski okrug;RS-12
RS;Toplicki okrug;RS-21
RS;Zajecarski okrug;RS-15
RS;Zapadnobacki okrug;RS-05
RS;Zlatiborski okrug;RS-16
RU;Adygeya, Respublika;RU-AD
RU;Altay, Respublika;RU-AL
RU;Altayskiy kray;RU-ALT
RU;Amurskaya oblast';RU-AMU
RU;Arkhangel'skaya oblast';RU-ARK
RU;Astrakhanskaya oblast';RU-AST
RU;Bashkortostan, Respublika;RU-BA
RU;Belgorodskaya oblast';RU-BEL
RU;Bryanskaya oblast';RU-BRY
RU;Buryatiya, Respublika;RU-BU
RU;Chechenskaya Respublika;RU-CE
RU;Chelyabinskaya oblast';RU-CHE
RU;Chukotskiy avtonomnyy okrug;RU-CHU
RU;Chuvashskaya Respublika;RU-CU
RU;Dagestan, Respublika;RU-DA
RU;Ingushetiya, Respublika;RU-IN
RU;Irkutskaya oblast';RU-IRK
RU;Ivanovskaya oblast';RU-IVA
RU;Kabardino-Balkarskaya Respublika;RU-KB
RU;Kaliningradskaya oblast';RU-KGD
RU;Kalmykiya, Respublika;RU-KL
RU;Kaluzhskaya oblast';RU-KLU
RU;Kamchatskiy kray;RU-KAM
RU;Karachayevo-Cherkesskaya Respublika;RU-KC
RU;Kareliya, Respublika;RU-KR
RU;Kemerovskaya oblast';RU-KEM
RU;Khabarovskiy kray;RU-KHA
RU;Khakasiya, Respublika;RU-KK
RU;Khanty-Mansiyskiy avtonomnyy okrug;RU-KHM
RU;Kirovskaya oblast';RU-KIR
RU;Komi, Respublika;RU-KO
RU;Kostromskaya oblast';RU-KOS
RU;Krasnodarskiy kray;RU-KDA
RU;Krasnoyarskiy kray;RU-KYA
RU;Kurganskaya oblast';RU-KGN
RU;Kurskaya oblast';RU-KRS
RU;Leningradskaya oblast';RU-LEN
RU;Lipetskaya oblast';RU-LIP
RU;Magadanskaya oblast';RU-MAG
RU;Mariy El, Respublika;RU-ME
RU;Mordoviya, Respublika;RU-MO
RU;Moskovskaya oblast';RU-MOS
RU;Moskva;RU-MOW
RU;Murmanskaya oblast';RU-MUR
RU;Nenetskiy avtonomnyy okrug;RU-NEN
RU;Nizhegorodskaya oblast';RU-NIZ
RU;Novgorodskaya oblast';RU-NGR
RU;Novosibirskaya oblast';RU-NVS
RU;Omskaya oblast';RU-OMS
RU;Orenburgskaya oblast';RU-ORE
RU;Orlovskaya oblast';RU-ORL
RU;Penzenskaya oblast';RU-PNZ
RU;Permskiy kray;RU-PER
RU;Primorskiy kray;RU-PRI
RU;Pskovskaya oblast';RU-PSK
RU;Rostovskaya oblast';RU-ROS
RU;Ryazanskaya oblast';RU-RYA
RU;Saha, Respublika;RU-SA
RU;Sakhalinskaya oblast';RU-SAK
RU;Samarskaya oblast';RU-SAM
RU;Sankt-Peterburg;RU-SPE
RU;Saratovskaya oblast';RU-SAR
RU;Severnaya Osetiya, Respublika;RU-SE
RU;Smolenskaya oblast';RU-SMO
RU;Stavropol'skiy kray;RU-STA
RU;Sverdlovskaya oblast';RU-SVE
RU;Tambovskaya oblast';RU-TAM
RU;Tatarstan, Respublika;RU-TA
RU;Tomskaya oblast';RU-TOM
RU;Tul'skaya oblast';RU-TUL
RU;Tverskaya oblast';RU-TVE
RU;Tyumenskaya oblast';RU-TYU
RU;Tyva, Respublika;RU-TY
RU;Udmurtskaya Respublika;RU-UD
RU;Ul'yanovskaya oblast';RU-ULY
RU;Vladimirskaya oblast';RU-VLA
RU;Volgogradskaya oblast';RU-VGG
RU;Vologodskaya oblast';RU-VLG
RU;Voronezhskaya oblast';RU-VOR
RU;Yamalo-Nenetskiy avtonomnyy okrug;RU-YAN
RU;Yaroslavskaya oblast';RU-YAR
RU;Yevreyskaya avtonomnaya oblast';RU-YEV
RU;Zabaykal'skiy kray;RU-ZAB
RW;Est;RW-02
RW;Nord;RW-03
RW;Ouest;RW-04
RW;Sud;RW-05
RW;Ville de Kigali;RW-01
SA;'Asir;SA-14
SA;Al Bahah;SA-11
SA;Al Hudud ash Shamaliyah;SA-08
SA;Al Jawf;SA-12
SA;Al Madinah al Munawwarah;SA-03
SA;Al Qasim;SA-05
SA;Ar Riyad;SA-01
SA;Ash Sharqiyah;SA-04
SA;Ha'il;SA-06
SA;Jazan;SA-09
SA;Makkah al Mukarramah;SA-02
SA;Najran;SA-10
SA;Tabuk;SA-07
SB;Choiseul;SB-CH
SB;Guadalcanal;SB-GU
SB;Western;SB-WE
SC;Anse Boileau;SC-02
SC;Anse Royale;SC-05
SC;Anse aux Pins;SC-01
SC;Baie Lazare;SC-06
SC;Baie Sainte Anne;SC-07
SC;Beau Vallon;SC-08
SC;Bel Ombre;SC-10
SC;Cascade;SC-11
SC;English River;SC-16
SC;Grand Anse Mahe;SC-13
SC;Grand Anse Praslin;SC-14
SC;La Digue;SC-15
SC;Pointe Larue;SC-20
SC;Takamaka;SC-23
SD;Blue Nile;SD-NB
SD;Central Darfur;SD-DC
SD;Gedaref;SD-GD
SD;Gezira;SD-GZ
SD;Kassala;SD-KA
SD;Khartoum;SD-KH
SD;North Darfur;SD-DN
SD;North Kordofan;SD-KN
SD;Northern;SD-NO
SD;Red Sea;SD-RS
SD;River Nile;SD-NR
SD;Sennar;SD-SI
SD;South Darfur;SD-DS
SD;South Kordofan;SD-KS
SD;West Darfur;SD-DW
SD;West Kordofan;SD-GK
SD;White Nile;SD-NW
SE;Blekinge lan;SE-K
SE;Dalarnas lan;SE-W
SE;Gavleborgs lan;SE-X
SE;Gotlands lan;SE-I
SE;Hallands lan;SE-N
SE;Jamtlands lan;SE-Z
SE;Jonkopings lan;SE-F
SE;Kalmar lan;SE-H
SE;Kronobergs lan;SE-G
SE;Norrbottens lan;SE-BD
SE;Orebro lan;SE-T
SE;Ostergotlands lan;SE-E
SE;Skane lan;SE-M
SE;Sodermanlands lan;SE-D
SE;Stockholms lan;SE-AB
SE;Uppsala lan;SE-C
SE;Varmlands lan;SE-S
SE;Vasterbottens lan;SE-AC
SE;Vasternorrlands lan;SE-Y
SE;Vastmanlands lan;SE-U
SE;Vastra Gotalands lan;SE-O
SG;Singapore;-
SH;Saint Helena;SH-HL
SI;Ajdovscina;SI-001
SI;Ankaran;SI-213
SI;Apace;SI-195
SI;Beltinci;SI-002
SI;Benedikt;SI-148
SI;Bistrica ob Sotli;SI-149
SI;Bled;SI-003
SI;Bloke;SI-150
SI;Bohinj;SI-004
SI;Borovnica;SI-005
SI;Bovec;SI-006
SI;Braslovce;SI-151
SI;Brda;SI-007
SI;Brezice;SI-009
SI;Brezovica;SI-008
SI;Cankova;SI-152
SI;Celje;SI-011
SI;Cerklje na Gorenjskem;SI-012
SI;Cerknica;SI-013
SI;Cerkno;SI-014
SI;Cirkulane;SI-196
SI;Crensovci;SI-015
SI;Crnomelj;SI-017
SI;Destrnik;SI-018
SI;Divaca;SI-019
SI;Dobje;SI-154
SI;Dobrepolje;SI-020
SI;Dobrna;SI-155
SI;Dobrova-Polhov Gradec;SI-021
SI;Dobrovnik;SI-156
SI;Domzale;SI-023
SI;Dornava;SI-024
SI;Dravograd;SI-025
SI;Duplek;SI-026
SI;Gorje;SI-207
SI;Gornja Radgona;SI-029
SI;Gornji Petrovci;SI-031
SI;Grad;SI-158
SI;Grosuplje;SI-032
SI;Hajdina;SI-159
SI;Hoce-Slivnica;SI-160
SI;Hodos;SI-161
SI;Horjul;SI-162
SI;Hrastnik;SI-034
SI;Hrpelje-Kozina;SI-035
SI;Idrija;SI-036
SI;Ig;SI-037
SI;Ilirska Bistrica;SI-038
SI;Ivancna Gorica;SI-039
SI;Izola;SI-040
SI;Jesenice;SI-041
SI;Jursinci;SI-042
SI;Kamnik;SI-043
SI;Kanal;SI-044
SI;Kidricevo;SI-045
SI;Kobarid;SI-046
SI;Kobilje;SI-047
SI;Kocevje;SI-048
SI;Komen;SI-049
SI;Komenda;SI-164
SI;Koper;SI-050
SI;Kosanjevica na Krki;SI-197
SI;Kostel;SI-165
SI;Kranj;SI-052
SI;Kranjska Gora;SI-053
SI;Krizevci;SI-166
SI;Krsko;SI-054
SI;Kungota;SI-055
SI;Kuzma;SI-056
SI;Lasko;SI-057
SI;Lenart;SI-058
SI;Lendava;SI-059
SI;Litija;SI-060
SI;Ljubljana;SI-061
SI;Ljutomer;SI-063
SI;Log-Dragomer;SI-208
SI;Logatec;SI-064
SI;Loska dolina;SI-065
SI;Loski Potok;SI-066
SI;Lovrenc na Pohorju;SI-167
SI;Luce;SI-067
SI;Lukovica;SI-068
SI;Majsperk;SI-069
SI;Makole;SI-198
SI;Maribor;SI-070
SI;Markovci;SI-168
SI;Medvode;SI-071
SI;Menges;SI-072
SI;Metlika;SI-073
SI;Mezica;SI-074
SI;Miklavz na Dravskem polju;SI-169
SI;Miren-Kostanjevica;SI-075
SI;Mirna;SI-212
SI;Mirna Pec;SI-170
SI;Mislinja;SI-076
SI;Mokronog-Trebelno;SI-199
SI;Moravce;SI-077
SI;Mozirje;SI-079
SI;Murska Sobota;SI-080
SI;Muta;SI-081
SI;Naklo;SI-082
SI;Nazarje;SI-083
SI;Nova Gorica;SI-084
SI;Novo Mesto;SI-085
SI;Odranci;SI-086
SI;Oplotnica;SI-171
SI;Ormoz;SI-087
SI;Piran;SI-090
SI;Pivka;SI-091
SI;Podcetrtek;SI-092
SI;Podlehnik;SI-172
SI;Poljcane;SI-200
SI;Polzela;SI-173
SI;Postojna;SI-094
SI;Prebold;SI-174
SI;Preddvor;SI-095
SI;Prevalje;SI-175
SI;Ptuj;SI-096
SI;Puconci;SI-097
SI;Race-Fram;SI-098
SI;Radece;SI-099
SI;Radenci;SI-100
SI;Radlje ob Dravi;SI-101
SI;Radovljica;SI-102
SI;Ravne na Koroskem;SI-103
SI;Razkrizje;SI-176
SI;Recica ob Savinji;SI-209
SI;Rence-Vogrsko;SI-201
SI;Ribnica;SI-104
SI;Rogaska Slatina;SI-106
SI;Rogasovci;SI-105
SI;Ruse;SI-108
SI;Salovci;SI-033
SI;Semic;SI-109
SI;Sempeter-Vrtojba;SI-183
SI;Sencur;SI-117
SI;Sentilj;SI-118
SI;Sentjernej;SI-119
SI;Sentjur;SI-120
SI;Sentrupert;SI-211
SI;Sevnica;SI-110
SI;Sezana;SI-111
SI;Skocjan;SI-121
SI;Skofja Loka;SI-122
SI;Skofljica;SI-123
SI;Slovenj Gradec;SI-112
SI;Slovenska Bistrica;SI-113
SI;Slovenske Konjice;SI-114
SI;Smarje pri Jelsah;SI-124
SI;Smarjeske Toplice;SI-206
SI;Smartno ob Paki;SI-125
SI;Smartno pri Litiji;SI-194
SI;Sodrazica;SI-179
SI;Solcava;SI-180
SI;Sostanj;SI-126
SI;Starse;SI-115
SI;Store;SI-127
SI;Straza;SI-203
SI;Sveta Trojica v Slovenskih goricah;SI-204
SI;Sveti Andraz v Slovenskih Goricah;SI-182
SI;Sveti Jurij ob Scavnici;SI-116
SI;Sveti Jurij v Slovenskih goricah;SI-210
SI;Sveti Tomaz;SI-205
SI;Tabor;SI-184
SI;Tisina;SI-010
SI;Tolmin;SI-128
SI;Trbovlje;SI-129
SI;Trebnje;SI-130
SI;Trnovska Vas;SI-185
SI;Trzic;SI-131
SI;Trzin;SI-186
SI;Turnisce;SI-132
SI;Velenje;SI-133
SI;Velika Polana;SI-187
SI;Velike Lasce;SI-134
SI;Verzej;SI-188
SI;Videm;SI-135
SI;Vipava;SI-136
SI;Vitanje;SI-137
SI;Vodice;SI-138
SI;Vojnik;SI-139
SI;Vransko;SI-189
SI;Vrhnika;SI-140
SI;Vuzenica;SI-141
SI;Zagorje ob Savi;SI-142
SI;Zalec;SI-190
SI;Zavrc;SI-143
SI;Zelezniki;SI-146
SI;Zetale;SI-191
SI;Ziri;SI-147
SI;Zrece;SI-144
SI;Zuzemberk;SI-193
SJ;Svalbard and Jan Mayen;-
SK;Banskobystricky kraj;SK-BC
SK;Bratislavsky kraj;SK-BL
SK;Kosicky kraj;SK-KI
SK;Nitriansky kraj;SK-NI
SK;Presovsky kraj;SK-PV
SK;Trenciansky kraj;SK-TC
SK;Trnavsky kraj;SK-TA
SK;Zilinsky kraj;SK-ZI
SL;Eastern;SL-E
SL;North Western;SL-NW
SL;Northern;SL-N
SL;Southern;SL-S
SL;Western Area;SL-W
SM;Chiesanuova;SM-02
SM;Citta di San Marino;SM-07
SM;Faetano;SM-04
SM;Serravalle;SM-09
SN;Dakar;SN-DK
SN;Diourbel;SN-DB
SN;Fatick;SN-FK
SN;Kaffrine;SN-KA
SN;Kaolack;SN-KL
SN;Kedougou;SN-KE
SN;Kolda;SN-KD
SN;Louga;SN-LG
SN;Matam;SN-MT
SN;Saint-Louis;SN-SL
SN;Sedhiou;SN-SE
SN;Tambacounda;SN-TC
SN;Thies;SN-TH
SN;Ziguinchor;SN-ZG
SO;Awdal;SO-AW
SO;Banaadir;SO-BN
SO;Bari;SO-BR
SO;Bay;SO-BY
SO;Gedo;SO-GE
SO;Hiiraan;SO-HI
SO;Jubbada Hoose;SO-JH
SO;Mudug;SO-MU
SO;Nugaal;SO-NU
SO;Sanaag;SO-SA
SO;Shabeellaha Hoose;SO-SH
SO;Sool;SO-SO
SO;Togdheer;SO-TO
SO;Woqooyi Galbeed;SO-WO
SR;Commewijne;SR-CM
SR;Nickerie;SR-NI
SR;Para;SR-PR
SR;Paramaribo;SR-PM
SR;Sipaliwini;SR-SI
SR;Wanica;SR-WA
SS;Central Equatoria;SS-EC
SS;Eastern Equatoria;SS-EE
SS;Northern Bahr el Ghazal;SS-BN
SS;Upper Nile;SS-NU
SS;Western Equatoria;SS-EW
ST;Agua Grande;ST-01
SV;Ahuachapan;SV-AH
SV;Cabanas;SV-CA
SV;Chalatenango;SV-CH
SV;Cuscatlan;SV-CU
SV;La Libertad;SV-LI
SV;La Paz;SV-PA
SV;La Union;SV-UN
SV;Morazan;SV-MO
SV;San Miguel;SV-SM
SV;San Salvador;SV-SS
SV;San Vicente;SV-SV
SV;Santa Ana;SV-SA
SV;Sonsonate;SV-SO
SV;Usulutan;SV-US
SX;Sint Maarten (Dutch Part);-
SY;Al Hasakah;SY-HA
SY;Al Ladhiqiyah;SY-LA
SY;Al Qunaytirah;SY-QU
SY;Ar Raqqah;SY-RA
SY;As Suwayda';SY-SU
SY;Dar'a;SY-DR
SY;Dayr az Zawr;SY-DY
SY;Dimashq;SY-DI
SY;Halab;SY-HL
SY;Hamah;SY-HM
SY;Hims;SY-HI
SY;Idlib;SY-ID
SY;Rif Dimashq;SY-RD
SY;Tartus;SY-TA
SZ;Hhohho;SZ-HH
SZ;Lubombo;SZ-LU
SZ;Manzini;SZ-MA
SZ;Shiselweni;SZ-SH
TC;Turks and Caicos Islands;-
TD;Bahr el Ghazal;TD-BG
TD;Chari-Baguirmi;TD-CB
TD;Lac;TD-LC
TD;Logone-Occidental;TD-LO
TD;Ouaddai;TD-OD
TD;Sila;TD-SI
TD;Ville de Ndjamena;TD-ND
TF;French Southern Territories;-
TG;Centrale;TG-C
TG;Kara;TG-K
TG;Maritime;TG-M
TG;Plateaux;TG-P
TG;Savanes;TG-S
TH;Amnat Charoen;TH-37
TH;Ang Thong;TH-15
TH;Bueng Kan;TH-38
TH;Buri Ram;TH-31
TH;Chachoengsao;TH-24
TH;Chai Nat;TH-18
TH;Chaiyaphum;TH-36
TH;Chanthaburi;TH-22
TH;Chiang Mai;TH-50
TH;Chiang Rai;TH-57
TH;Chon Buri;TH-20
TH;Chumphon;TH-86
TH;Kalasin;TH-46
TH;Kamphaeng Phet;TH-62
TH;Kanchanaburi;TH-71
TH;Khon Kaen;TH-40
TH;Krabi;TH-81
TH;Krung Thep Maha Nakhon;TH-10
TH;Lampang;TH-52
TH;Lamphun;TH-51
TH;Loei;TH-42
TH;Lop Buri;TH-16
TH;Mae Hong Son;TH-58
TH;Maha Sarakham;TH-44
TH;Mukdahan;TH-49
TH;Nakhon Nayok;TH-26
TH;Nakhon Pathom;TH-73
TH;Nakhon Phanom;TH-48
TH;Nakhon Ratchasima;TH-30
TH;Nakhon Sawan;TH-60
TH;Nakhon Si Thammarat;TH-80
TH;Nan;TH-55
TH;Narathiwat;TH-96
TH;Nong Bua Lam Phu;TH-39
TH;Nong Khai;TH-43
TH;Nonthaburi;TH-12
TH;Pathum Thani;TH-13
TH;Pattani;TH-94
TH;Phangnga;TH-82
TH;Phatthalung;TH-93
TH;Phayao;TH-56
TH;Phetchabun;TH-67
TH;Phetchaburi;TH-76
TH;Phichit;TH-66
TH;Phitsanulok;TH-65
TH;Phra Nakhon Si Ayutthaya;TH-14
TH;Phrae;TH-54
TH;Phuket;TH-83
TH;Prachin Buri;TH-25
TH;Prachuap Khiri Khan;TH-77
TH;Ranong;TH-85
TH;Ratchaburi;TH-70
TH;Rayong;TH-21
TH;Roi Et;TH-45
TH;Sa Kaeo;TH-27
TH;Sakon Nakhon;TH-47
TH;Samut Prakan;TH-11
TH;Samut Sakhon;TH-74
TH;Samut Songkhram;TH-75
TH;Saraburi;TH-19
TH;Satun;TH-91
TH;Si Sa Ket;TH-33
TH;Sing Buri;TH-17
TH;Songkhla;TH-90
TH;Sukhothai;TH-64
TH;Suphan Buri;TH-72
TH;Surat Thani;TH-84
TH;Surin;TH-32
TH;Tak;TH-63
TH;Trang;TH-92
TH;Trat;TH-23
TH;Ubon Ratchathani;TH-34
TH;Udon Thani;TH-41
TH;Uthai Thani;TH-61
TH;Uttaradit;TH-53
TH;Yala;TH-95
TH;Yasothon;TH-35
TJ;Dushanbe;TJ-DU
TJ;Khatlon;TJ-KT
TJ;Kuhistoni Badakhshon;TJ-GB
TJ;Nohiyahoi Tobei Jumhuri;TJ-RA
TJ;Sughd;TJ-SU
TK;Tokelau;-
TL;Ainaro;TL-AN
TL;Bobonaro;TL-BO
TL;Cova Lima;TL-CO
TL;Dili;TL-DI
TL;Liquica;TL-LI
TM;Ahal;TM-A
TM;Balkan;TM-B
TM;Dasoguz;TM-D
TM;Lebap;TM-L
TM;Mary;TM-M
TN;Beja;TN-31
TN;Ben Arous;TN-13
TN;Bizerte;TN-23
TN;Gabes;TN-81
TN;Gafsa;TN-71
TN;Jendouba;TN-32
TN;Kairouan;TN-41
TN;Kasserine;TN-42
TN;Kebili;TN-73
TN;L'Ariana;TN-12
TN;La Manouba;TN-14
TN;Le Kef;TN-33
TN;Mahdia;TN-53
TN;Medenine;TN-82
TN;Monastir;TN-52
TN;Nabeul;TN-21
TN;Sfax;TN-61
TN;Sidi Bouzid;TN-43
TN;Siliana;TN-34
TN;Sousse;TN-51
TN;Tataouine;TN-83
TN;Tozeur;TN-72
TN;Tunis;TN-11
TN;Zaghouan;TN-22
TO;Tongatapu;TO-04
TR;Adana;TR-01
TR;Adiyaman;TR-02
TR;Afyonkarahisar;TR-03
TR;Agri;TR-04
TR;Aksaray;TR-68
TR;Amasya;TR-05
TR;Ankara;TR-06
TR;Antalya;TR-07
TR;Ardahan;TR-75
TR;Artvin;TR-08
TR;Aydin;TR-09
TR;Balikesir;TR-10
TR;Bartin;TR-74
TR;Batman;TR-72
TR;Bayburt;TR-69
TR;Bilecik;TR-11
TR;Bingol;TR-12
TR;Bitlis;TR-13
TR;Bolu;TR-14
TR;Burdur;TR-15
TR;Bursa;TR-16
TR;Canakkale;TR-17
TR;Cankiri;TR-18
TR;Corum;TR-19
TR;Denizli;TR-20
TR;Diyarbakir;TR-21
TR;Duzce;TR-81
TR;Edirne;TR-22
TR;Elazig;TR-23
TR;Erzincan;TR-24
TR;Erzurum;TR-25
TR;Eskisehir;TR-26
TR;Gaziantep;TR-27
TR;Giresun;TR-28
TR;Gumushane;TR-29
TR;Hakkari;TR-30
TR;Hatay;TR-31
TR;Igdir;TR-76
TR;Isparta;TR-32
TR;Istanbul;TR-34
TR;Izmir;TR-35
TR;Kahramanmaras;TR-46
TR;Karabuk;TR-78
TR;Karaman;TR-70
TR;Kars;TR-36
TR;Kastamonu;TR-37
TR;Kayseri;TR-38
TR;Kilis;TR-79
TR;Kirikkale;TR-71
TR;Kirklareli;TR-39
TR;Kirsehir;TR-40
TR;Kocaeli;TR-41
TR;Konya;TR-42
TR;Kutahya;TR-43
TR;Malatya;TR-44
TR;Manisa;TR-45
TR;Mardin;TR-47
TR;Mersin;TR-33
TR;Mugla;TR-48
TR;Mus;TR-49
TR;Nevsehir;TR-50
TR;Nigde;TR-51
TR;Ordu;TR-52
TR;Osmaniye;TR-80
TR;Rize;TR-53
TR;Sakarya;TR-54
TR;Samsun;TR-55
TR;Sanliurfa;TR-63
TR;Siirt;TR-56
TR;Sinop;TR-57
TR;Sirnak;TR-73
TR;Sivas;TR-58
TR;Tekirdag;TR-59
TR;Tokat;TR-60
TR;Trabzon;TR-61
TR;Tunceli;TR-62
TR;Usak;TR-64
TR;Van;TR-65
TR;Yalova;TR-77
TR;Yozgat;TR-66
TR;Zonguldak;TR-67
TT;Arima;TT-ARI
TT;Chaguanas;TT-CHA
TT;Couva-Tabaquite-Talparo;TT-CTT
TT;Diego Martin;TT-DMN
TT;Mayaro-Rio Claro;TT-MRC
TT;Penal-Debe;TT-PED
TT;Point Fortin;TT-PTF
TT;Port of Spain;TT-POS
TT;Princes Town;TT-PRT
TT;San Fernando;TT-SFO
TT;San Juan-Laventille;TT-SJL
TT;Sangre Grande;TT-SGE
TT;Siparia;TT-SIP
TT;Tobago;TT-TOB
TT;Tunapuna-Piarco;TT-TUP
TV;Funafuti;TV-FUN
TW;Changhua;TW-CHA
TW;Chiayi;TW-CYQ
TW;Hsinchu;TW-HSQ
TW;Hualien;TW-HUA
TW;Kaohsiung;TW-KHH
TW;Keelung;TW-KEE
TW;Kinmen;TW-KIN
TW;Lienchiang;TW-LIE
TW;Miaoli;TW-MIA
TW;Nantou;TW-NAN
TW;New Taipei;TW-NWT
TW;Penghu;TW-PEN
TW;Pingtung;TW-PIF
TW;Taichung;TW-TXG
TW;Tainan;TW-TNN
TW;Taipei;TW-TPE
TW;Taitung;TW-TTT
TW;Taoyuan;TW-TAO
TW;Yilan;TW-ILA
TW;Yunlin;TW-YUN
TZ;Arusha;TZ-01
TZ;Dar es Salaam;TZ-02
TZ;Dodoma;TZ-03
TZ;Geita;TZ-27
TZ;Iringa;TZ-04
TZ;Kagera;TZ-05
TZ;Kaskazini Pemba;TZ-06
TZ;Kaskazini Unguja;TZ-07
TZ;Katavi;TZ-28
TZ;Kigoma;TZ-08
TZ;Kilimanjaro;TZ-09
TZ;Kusini Pemba;TZ-10
TZ;Kusini Unguja;TZ-11
TZ;Lindi;TZ-12
TZ;Manyara;TZ-26
TZ;Mara;TZ-13
TZ;Mbeya;TZ-14
TZ;Mjini Magharibi;TZ-15
TZ;Morogoro;TZ-16
TZ;Mtwara;TZ-17
TZ;Mwanza;TZ-18
TZ;Njombe;TZ-29
TZ;Pwani;TZ-19
TZ;Rukwa;TZ-20
TZ;Ruvuma;TZ-21
TZ;Shinyanga;TZ-22
TZ;Simiyu;TZ-30
TZ;Singida;TZ-23
TZ;Songwe;TZ-31
TZ;Tabora;TZ-24
TZ;Tanga;TZ-25
UA;Avtonomna Respublika Krym;UA-43
UA;Cherkaska oblast;UA-71
UA;Chernihivska oblast;UA-74
UA;Chernivetska oblast;UA-77
UA;Dnipropetrovska oblast;UA-12
UA;Donetska oblast;UA-14
UA;Ivano-Frankivska oblast;UA-26
UA;Kharkivska oblast;UA-63
UA;Khersonska oblast;UA-65
UA;Khmelnytska oblast;UA-68
UA;Kirovohradska oblast;UA-35
UA;Kyiv;UA-30
UA;Kyivska oblast;UA-32
UA;Luhanska oblast;UA-09
UA;Lvivska oblast;UA-46
UA;Mykolaivska oblast;UA-48
UA;Odeska oblast;UA-51
UA;Poltavska oblast;UA-53
UA;Rivnenska oblast;UA-56
UA;Sevastopol;UA-40
UA;Sumska oblast;UA-59
UA;Ternopilska oblast;UA-61
UA;Vinnytska oblast;UA-05
UA;Volynska oblast;UA-07
UA;Zakarpatska oblast;UA-21
UA;Zaporizka oblast;UA-23
UA;Zhytomyrska oblast;UA-18
UG;Abim;UG-314
UG;Adjumani;UG-301
UG;Alebtong;UG-323
UG;Amolatar;UG-315
UG;Amudat;UG-324
UG;Amuria;UG-216
UG;Amuru;UG-316
UG;Apac;UG-302
UG;Arua;UG-303
UG;Budaka;UG-217
UG;Bududa;UG-218
UG;Bugiri;UG-201
UG;Buhweju;UG-420
UG;Buikwe;UG-117
UG;Bukedea;UG-219
UG;Bukomansibi;UG-118
UG;Bukwo;UG-220
UG;Bulambuli;UG-225
UG;Bundibugyo;UG-401
UG;Bushenyi;UG-402
UG;Busia;UG-202
UG;Butaleja;UG-221
UG;Buvuma;UG-120
UG;Buyende;UG-226
UG;Dokolo;UG-317
UG;Gomba;UG-121
UG;Gulu;UG-304
UG;Hoima;UG-403
UG;Ibanda;UG-417
UG;Iganga;UG-203
UG;Isingiro;UG-418
UG;Jinja;UG-204
UG;Kaabong;UG-318
UG;Kabale;UG-404
UG;Kabarole;UG-405
UG;Kaberamaido;UG-213
UG;Kalangala;UG-101
UG;Kaliro;UG-222
UG;Kalungu;UG-122
UG;Kampala;UG-102
UG;Kamuli;UG-205
UG;Kamwenge;UG-413
UG;Kapchorwa;UG-206
UG;Kasese;UG-406
UG;Katakwi;UG-207
UG;Kayunga;UG-112
UG;Kibaale;UG-407
UG;Kiboga;UG-103
UG;Kibuku;UG-227
UG;Kiruhura;UG-419
UG;Kiryandongo;UG-421
UG;Kisoro;UG-408
UG;Kitgum;UG-305
UG;Koboko;UG-319
UG;Kotido;UG-306
UG;Kumi;UG-208
UG;Kween;UG-228
UG;Kyankwanzi;UG-123
UG;Kyegegwa;UG-422
UG;Kyenjojo;UG-415
UG;Lamwo;UG-326
UG;Lira;UG-307
UG;Luuka;UG-229
UG;Luwero;UG-104
UG;Lwengo;UG-124
UG;Lyantonde;UG-114
UG;Manafwa;UG-223
UG;Masaka;UG-105
UG;Masindi;UG-409
UG;Mayuge;UG-214
UG;Mbale;UG-209
UG;Mbarara;UG-410
UG;Mitooma;UG-423
UG;Mityana;UG-115
UG;Moroto;UG-308
UG;Moyo;UG-309
UG;Mpigi;UG-106
UG;Mubende;UG-107
UG;Mukono;UG-108
UG;Nakapiripirit;UG-311
UG;Nakaseke;UG-116
UG;Nakasongola;UG-109
UG;Namayingo;UG-230
UG;Namutumba;UG-224
UG;Napak;UG-327
UG;Nebbi;UG-310
UG;Ngora;UG-231
UG;Ntungamo;UG-411
UG;Nwoya;UG-328
UG;Oyam;UG-321
UG;Pader;UG-312
UG;Pallisa;UG-210
UG;Rakai;UG-110
UG;Rubirizi;UG-425
UG;Rukungiri;UG-412
UG;Sembabule;UG-111
UG;Serere;UG-232
UG;Sheema;UG-426
UG;Sironko;UG-215
UG;Soroti;UG-211
UG;Tororo;UG-212
UG;Wakiso;UG-113
UG;Yumbe;UG-313
UG;Zombo;UG-330
UM;Palmyra Atoll;UM-95
US;Alabama;US-AL
US;Alaska;US-AK
US;Arizona;US-AZ
US;Arkansas;US-AR
US;California;US-CA
US;Colorado;US-CO
US;Connecticut;US-CT
US;Delaware;US-DE
US;District of Columbia;US-DC
US;Florida;US-FL
US;Georgia;US-GA
US;Hawaii;US-HI
US;Idaho;US-ID
US;Illinois;US-IL
US;Indiana;US-IN
US;Iowa;US-IA
US;Kansas;US-KS
US;Kentucky;US-KY
US;Louisiana;US-LA
US;Maine;US-ME
US;Maryland;US-MD
US;Massachusetts;US-MA
US;Michigan;US-MI
US;Minnesota;US-MN
US;Mississippi;US-MS
US;Missouri;US-MO
US;Montana;US-MT
US;Nebraska;US-NE
US;Nevada;US-NV
US;New Hampshire;US-NH
US;New Jersey;US-NJ
US;New Mexico;US-NM
US;New York;US-NY
US;North Carolina;US-NC
US;North Dakota;US-ND
US;Ohio;US-OH
US;Oklahoma;US-OK
US;Oregon;US-OR
US;Pennsylvania;US-PA
US;Rhode Island;US-RI
US;South Carolina;US-SC
US;South Dakota;US-SD
US;Tennessee;US-TN
US;Texas;US-TX
US;Utah;US-UT
US;Vermont;US-VT
US;Virginia;US-VA
US;Washington;US-WA
US;West Virginia;US-WV
US;Wisconsin;US-WI
US;Wyoming;US-WY
UY;Artigas;UY-AR
UY;Canelones;UY-CA
UY;Cerro Largo;UY-CL
UY;Colonia;UY-CO
UY;Durazno;UY-DU
UY;Flores;UY-FS
UY;Florida;UY-FD
UY;Lavalleja;UY-LA
UY;Maldonado;UY-MA
UY;Montevideo;UY-MO
UY;Paysandu;UY-PA
UY;Rio Negro;UY-RN
UY;Rivera;UY-RV
UY;Rocha;UY-RO
UY;Salto;UY-SA
UY;San Jose;UY-SJ
UY;Soriano;UY-SO
UY;Tacuarembo;UY-TA
UY;Treinta y Tres;UY-TT
UZ;Andijon;UZ-AN
UZ;Buxoro;UZ-BU
UZ;Farg'ona;UZ-FA
UZ;Jizzax;UZ-JI
UZ;Namangan;UZ-NG
UZ;Navoiy;UZ-NW
UZ;Qashqadaryo;UZ-QA
UZ;Qoraqalpog'iston Respublikasi;UZ-QR
UZ;Samarqand;UZ-SA
UZ;Sirdaryo;UZ-SI
UZ;Surxondaryo;UZ-SU
UZ;Toshkent;UZ-TK
UZ;Xorazm;UZ-XO
VA;Vatican City;-
VC;Charlotte;VC-01
VC;Grenadines;VC-06
VC;Saint George;VC-04
VC;Saint Patrick;VC-05
VE;Amazonas;VE-Z
VE;Anzoategui;VE-B
VE;Apure;VE-C
VE;Aragua;VE-D
VE;Barinas;VE-E
VE;Bolivar;VE-F
VE;Carabobo;VE-G
VE;Cojedes;VE-H
VE;Delta Amacuro;VE-Y
VE;Distrito Capital;VE-A
VE;Falcon;VE-I
VE;Guarico;VE-J
VE;La Guaira;VE-X
VE;Lara;VE-K
VE;Merida;VE-L
VE;Miranda;VE-M
VE;Monagas;VE-N
VE;Nueva Esparta;VE-O
VE;Portuguesa;VE-P
VE;Sucre;VE-R
VE;Tachira;VE-S
VE;Trujillo;VE-T
VE;Yaracuy;VE-U
VE;Zulia;VE-V
VG;Virgin Islands, British;-
VI;Virgin Islands, U.S.;-
VN;An Giang;VN-44
VN;Ba Ria - Vung Tau;VN-43
VN;Bac Giang;VN-54
VN;Bac Kan;VN-53
VN;Bac Lieu;VN-55
VN;Bac Ninh;VN-56
VN;Ben Tre;VN-50
VN;Binh Dinh;VN-31
VN;Binh Duong;VN-57
VN;Binh Phuoc;VN-58
VN;Binh Thuan;VN-40
VN;Ca Mau;VN-59
VN;Can Tho;VN-CT
VN;Cao Bang;VN-04
VN;Da Nang;VN-DN
VN;Dak Lak;VN-33
VN;Dak Nong;VN-72
VN;Dien Bien;VN-71
VN;Dong Nai;VN-39
VN;Dong Thap;VN-45
VN;Gia Lai;VN-30
VN;Ha Giang;VN-03
VN;Ha Nam;VN-63
VN;Ha Noi;VN-HN
VN;Ha Tinh;VN-23
VN;Hai Duong;VN-61
VN;Hai Phong;VN-HP
VN;Hau Giang;VN-73
VN;Ho Chi Minh;VN-SG
VN;Hoa Binh;VN-14
VN;Hung Yen;VN-66
VN;Khanh Hoa;VN-34
VN;Kien Giang;VN-47
VN;Kon Tum;VN-28
VN;Lai Chau;VN-01
VN;Lam Dong;VN-35
VN;Lang Son;VN-09
VN;Lao Cai;VN-02
VN;Long An;VN-41
VN;Nam Dinh;VN-67
VN;Nghe An;VN-22
VN;Ninh Binh;VN-18
VN;Ninh Thuan;VN-36
VN;Phu Tho;VN-68
VN;Phu Yen;VN-32
VN;Quang Binh;VN-24
VN;Quang Nam;VN-27
VN;Quang Ngai;VN-29
VN;Quang Ninh;VN-13
VN;Quang Tri;VN-25
VN;Soc Trang;VN-52
VN;Son La;VN-05
VN;Tay Ninh;VN-37
VN;Thai Binh;VN-20
VN;Thai Nguyen;VN-69
VN;Thanh Hoa;VN-21
VN;Thua Thien-Hue;VN-26
VN;Tien Giang;VN-46
VN;Tra Vinh;VN-51
VN;Tuyen Quang;VN-07
VN;Vinh Long;VN-49
VN;Vinh Phuc;VN-70
VN;Yen Bai;VN-06
VU;Shefa;VU-SEE
VU;Tafea;VU-TAE
VU;Torba;VU-TOB
WF;Sigave;WF-SG
WF;Uvea;WF-UV
WS;Atua;WS-AT
WS;Fa'asaleleaga;WS-FA
WS;Tuamasaga;WS-TU
YE;'Adan;YE-AD
YE;'Amran;YE-AM
YE;Abyan;YE-AB
YE;Ad Dali';YE-DA
YE;Al Bayda';YE-BA
YE;Al Hudaydah;YE-HU
YE;Al Mahrah;YE-MR
YE;Amanat al 'Asimah;YE-SA
YE;Dhamar;YE-DH
YE;Hadramawt;YE-HD
YE;Hajjah;YE-HJ
YE;Ibb;YE-IB
YE;Lahij;YE-LA
YE;Ma'rib;YE-MA
YE;Sa'dah;YE-SD
YE;San'a';YE-SN
YE;Shabwah;YE-SH
YE;Ta'izz;YE-TA
YT;Bandraboua;-
YT;Bandrele;-
YT;Kani-Keli;-
YT;Mamoudzou;-
YT;Ouangani;-
YT;Pamandzi;-
YT;Sada;-
ZA;Eastern Cape;ZA-EC
ZA;Free State;ZA-FS
ZA;Gauteng;ZA-GP
ZA;Kwazulu-Natal;ZA-KZN
ZA;Limpopo;ZA-LP
ZA;Mpumalanga;ZA-MP
ZA;North-West;ZA-NW
ZA;Northern Cape;ZA-NC
ZA;Western Cape;ZA-WC
ZM;Central;ZM-02
ZM;Copperbelt;ZM-08
ZM;Eastern;ZM-03
ZM;Luapula;ZM-04
ZM;Lusaka;ZM-09
ZM;Muchinga;ZM-10
ZM;North-Western;ZM-06
ZM;Northern;ZM-05
ZM;Southern;ZM-07
ZM;Western;ZM-01
ZW;Bulawayo;ZW-BU
ZW;Harare;ZW-HA
ZW;Manicaland;ZW-MA
ZW;Mashonaland Central;ZW-MC
ZW;Mashonaland East;ZW-ME
ZW;Mashonaland West;ZW-MW
ZW;Masvingo;ZW-MV
ZW;Matabeleland North;ZW-MN
ZW;Matabeleland South;ZW-MS
ZW;Midlands;ZW-MI";

    public static IEnumerable<StateRow> GetStates()
    {
        var rows = States.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
            .Select(line =>
            {
                var items = line.Split(";");

                var start = items[2].IndexOf("-", StringComparison.Ordinal);
                var length = items[2].Length;

                var codeExists = start != length - 1;
                var code = codeExists ? items[2][(start + 1)..] : null;

                return new StateRow
                {
                    CountryCode = items[0],
                    Name = items[1],
                    Code = code
                };
            });

        return rows;
    }
}