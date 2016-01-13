# ODBoard
OdrorirBoard ( hade namn wPlan innan ) WorkPlan.
Odrorir - Var kittlen som Dvärgarna bryggde mjöd i , Nordisk mytologi. De som beblandade sig med Odrorir fick kunskap inom
poesi och utbildningar.

### Webb Applikation

Idén är långt ifrån klar.
Tanken är att det ska fungera som ett TeamBoard.
Har påbörjat Admin arean.
Lagt till Notifications, Labels, med hjälp utav Bootstrap, Jquery, Modal. 
Som används i VIEWS för TEAM och Projekt, se kod där i....

Trello API ska kunna kopplas på, även Github, #slack.

#### Grund/Tanke

+ SQL Databas
+ Grupp, Roller, Identity 2.0, Användare.
+ Användare reggar sig, Skapar Team, Gör sig själv till TeamAdmin, Skapar projekt kopplat till Team id,
Lägger till användare om man vill, Delar ut uppgifter, Laddar upp projekt filer.
I samma veva som man skapar Team, så ska man få frågan om man vill skapa en #slack kanal som e kopplat till Teamets användare.

## Team
+ TeamState i VIEW , som hämtar från Areas/BackEnd/Models/TeamViewModel.cs

## Kod
@foreach (var item in Model)
 {
   var teamstate = OdrorirBoard.Areas.BackEnd.Models.TeamViewModel.LabelState.Active == item.TeamState ? "label-success" : "label-info";

Indikerar hur Statusen är satt, Active, Private, NotActive.

## Projekt
+ ProjektState i VIEW, Hämtas från Areas/BackEnd/Models/ProjectsViewModel.cs

## Kod
@foreach (var item in Model)
                            {
                                var projectActive = OdrorirBoard.Areas.BackEnd.Models.ProjectsViewModel.ProjectLabelState.Active == item.ProjectState? "label-success" : "label-info";
                                var projectInactive = OdrorirBoard.Areas.BackEnd.Models.ProjectsViewModel.ProjectLabelState.NotActive == item.ProjectState ? "label-default" : "label-error";
                                var projectComplete = OdrorirBoard.Areas.BackEnd.Models.ProjectsViewModel.ProjectLabelState.Complete == item.ProjectState ? "label-success" : "label-info";
                                var projectAlpha = OdrorirBoard.Areas.BackEnd.Models.ProjectsViewModel.ProjectLabelState.Alpha == item.ProjectState ? "label-warning" : "label-info";
                                var projectBeta = OdrorirBoard.Areas.BackEnd.Models.ProjectsViewModel.ProjectLabelState.Beta == item.ProjectState ? "label-warning" : "label-info";
                                var projectOptimizing = OdrorirBoard.Areas.BackEnd.Models.ProjectsViewModel.ProjectLabelState.Optimizing == item.ProjectState ? "label-success" : "label-warning";

<td>
<span class="label @projectActive @projectInactive @projectComplete @projectAlpha @projectBeta @projectOptimizing">@item.ProjectState</span>
</td>

	
####Mer idéer finns, 
Har lagt ungefär totalt 16-20 timmar på det som finns där nu. Jobbar med projektet när tid finns på fritiden.



