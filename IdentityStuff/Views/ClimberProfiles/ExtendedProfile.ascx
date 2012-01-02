<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExtendedProfile.ascx.cs" Inherits="IdentityStuff.Views.ClimberProfiles.ExtendedProfile" %>

<%= displayExtendedProfilePart("Grades I climb <span style='font-weight:normal'>(<a href='/Climbing-Grade-Comparison-Chart-Converter' target='_blank'>see grade chart</a>)</span>", extendedProfile.Grades)%>
<%= displayExtendedProfilePart("Types of climbing I enjoy", extendedProfile.LikeToClimb) %>
<%= displayExtendedProfilePart("Climbing ambitions", extendedProfile.ClimbingAmbitions) %>
<%= displayExtendedProfilePart("Best ever climbing moment", extendedProfile.BestMoment) %>
<%= displayExtendedProfilePart("Favorite places / routes I've climbed", extendedProfile.FavoritePlaces) %>
<%= displayExtendedProfilePart("Places / routes I would like to climb", extendedProfile.PlacesIWouldLikeToClimb) %>

<%= displayExtendedProfilePart("Competitions I compete in", extendedProfile.CompetitionsICompeteIn) %>
<%= displayExtendedProfilePart("Projects (specific climbs) I'm working on", extendedProfile.CurrentProjects) %>

<%= displayExtendedProfilePart("Role models" ,extendedProfile.RoleModels) %>
<%= displayExtendedProfilePart("Favorite climbing brands", extendedProfile.FavoriteBrands) %>

<%= displayExtendedProfilePart("What I like about Climbfind", extendedProfile.LikeAboutClimbfind) %>            
<%= displayExtendedProfilePart("What I think could be better about Climbfind" ,extendedProfile.DislikeAboutClimbfind) %>            

<%= displayExtendedProfilePart("General climbing history", extendedProfile.ClimbingHistory) %>
