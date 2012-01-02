<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CF.Master" AutoEventWireup="true" CodeBehind="GradeConverter.aspx.cs" Inherits="IdentityStuff.Views.Home.GradeConverter" %>

<asp:Content ID="m" ContentPlaceHolderID="m" runat="server">

    <h1>Rock climbing grades converter chart</h1>

<p>Here is our attempt to compare a few of the many grading systems from around the world as well as a little about each of them. </p>
<p><span style="font-weight:bold;color:Red">Note:</span> this is only an approximate conversion table which appears slightly different in
different browsers and is best viewed in FireFox. For a completely accurate view, buy a guide book!</p>


    <table style="text-align: center;">
        <tbody><tr>
            <th style="width: 80px;">French (sport)</th>        
            <th style="width: 80px;">UIAA</th>
            <th style="width: 80px;">USA</th>
            <th style="width: 80px;">Australia</th>
            <th style="width: 80px;">Hueco<br/><font size="1">(bouldering)</font></th>
            <th style="width: 80px;">Fontainebleau<br/><font size="1">(bouldering)</font></th>
        </tr>
        <tr>

            <td style="font-size: 11px; line-height: 1.37em;">
                <div>1</div>
                <div>2</div>
                <div>2+</div>
                <div>3-</div>
                <div>3</div>

                <div>3+</div>
                <div>4</div>
                <div>4+</div>
                <div>5</div>
                <div>5+</div>
                <div>6a</div>

                <div>6a+</div>
                <div>6b</div>
                <div>6b+</div>
                <div>6c</div>
                <div>6c+</div>
                <div>7a</div>

                <div>7a+</div>
                <div>7b</div>
                <div>7b+</div>
                <div>7c</div>
                <div>7c+</div>
                <div>8a</div>                                
                <div>8a+</div>                             
                <div>8b</div>

                <div>8b+</div>                                
                <div>8c</div>                             
                <div>9a</div>                                             
                <div>9a+</div>                               
            </td>        
            <td style="font-size: 10.5px;">
                <div style="line-height: 1.31em;">
                    <div>I</div>
                    <div>II</div>

                    <div>III</div>
                    <div>III+</div>
                    <div>IV</div>
                    <div>IV+</div>
                    <div>V-</div>
                    <div>V</div>

                    <div>V+</div>
                    <div>VI-</div>
                </div>
                <div style="line-height: 1.61em;">
                    <div>VI</div>
                    <div>VI+</div>
                    <div>VII-</div>

                    <div>VII</div>
                    <div>VII+</div>
                    <div>VIII-</div>
                    <div>VIII</div>
                    <div>VIII+</div>
                    <div>IX-</div>

                    <div>IX</div>
                    <div>IX+</div>
                    <div>X-</div>
                    <div>X</div>
                    <div>X+</div>
                    <div>XI-</div>

                    <div>XI</div>
                    <div>XI+</div>
                </div>             
            </td>
            <td style="font-size: 11px; line-height: 1.34em;">
                <div>5.1</div>
                <div>5.2</div>

                <div>5.3</div>
                <div>5.4</div>
                <div>5.5</div>
                <div>5.6</div>
                <div>5.7</div>
                <div>5.8</div>

                <div>5.9</div>
                <div>5.10a</div>
                <div>5.10b</div>
                <div>5.10c</div>
                <div>5.10d</div>
                <div>5.11a</div>

                <div>5.11b</div>
                <div>5.11c</div>
                <div>5.11d</div>
                <div>5.12a</div>
                <div>5.12b</div>
                <div>5.12c</div>

                <div>5.12d</div>
                <div>5.13a</div>
                <div>5.13b</div>
                <div>5.13c</div>
                <div>5.13d</div>
                <div>5.14a</div>

                <div>5.14b</div>
                <div>5.14c</div>
                <div>5.14d</div>          
                <div>5.15a</div>  
            </td>
            <td style="font-size: 13px; line-height: 1.37em;">
                <div>4</div>

                <div>6</div>
                <div>8</div>
                <div>10</div>
                <div>12</div>
                <div>14</div>
                <div>16</div>

                <div>18</div>
                <div>19</div>
                <div>20</div>
                <div>21</div>
                <div>22</div>
                <div>23</div>
                <div>24</div>
                <div>25</div>
                <div>26</div>
                <div>27</div>
                <div>28</div>
                <div>29</div>
                <div>30</div>
                <div>31</div>
                <div>32</div>
                <div>33</div>                                
                <div>34</div>                             
                <div>35</div>                   
            </td>
            <td style="font-size: 11px; line-height: 1.37em;">
              <div>-</div>
                <div>-</div>
                <div>-</div>
                <div>-</div>
                <div>-</div>

                <div>-</div>
                <div>-</div>
                <div>-</div>
                <div>V0-</div>
                <div>V0</div>
                <div>V0+</div>

                <div>V0+</div>
                <div>V1</div>
                <div>V1+</div>
                <div>V2</div>
                <div>V3</div>
                <div>V4</div>

                <div>V4</div>
                <div>V5</div>
                <div>V6</div>
                <div>V6</div>
                <div>V7</div>
                <div>V8</div>                                
                <div>V9</div>                             
                <div>V9</div>

                <div>V10</div>                                
                <div>V11</div>                             
                <div>V12</div>                                             
                <div>V13</div>                  
            </td>  
             <td style="font-size: 11px; line-height: 1.37em;">
              <div>-</div>
                <div>-</div>
                <div>-</div>
                <div>-</div>
                <div>-</div>

                <div>-</div>
                <div>-</div>
                <div>-</div>
                <div>3</div>
                <div>4</div>
                <div>4+</div>

                <div>4+</div>
                <div>5</div>
                <div>5</div>
                <div>5+</div>
                <div>6a</div>
                <div>6b</div>

                <div>6b+</div>
                <div>6c</div>
                <div>7a</div>
                <div>7a</div>
                <div>7a+</div>
                <div>7b</div>                                
                <div>7c</div>                             
                <div>7c</div>

                <div>7c+</div>                                
                <div>8a</div>                             
                <div>8a+</div>                                             
                <div>8b</div>                  
            </td>           
        </tr>
    </tbody></table>

 <p><b>French</b>: Used most commonly to grade sport routes, it takes the dificulty of the moves and the length of the climb into consideration. It starts at 1 and each grade can further sub-divided using the letters a, b or c. It is common for the higher grades to also be given a + or - to further refine their grade. This grading system is often confused with the Fontainebleau grading system.</p>
 <p><b>UIAA</b>: Standing for "Union Internationale des Associations d'Alpinisme", this grading system is most commonly used in Germany, Austria and Switzerland.</p>
 <p><b>USA</b>: A part of the Yosemite Decimal System (YDS), the 5 signifies that it is a technical climb where a fall without protect would result in injury or death. The number after the decimal place signifies the difficulty and can also be subdivided with a letter from a-d.</p>
 <p><b>Australia</b>: It is worth mentioning that the grade is based purely on the hardest move thus a sustained 21 with 20 moves at that grade would have the same grade as a one move wonder. This grading system is also used in New Zealand and South Africa.</p>
 <p><b>Hueco</b>: Developed in America by John Sherman, the Hueco Scale is most commonly used in America to relate the difficulty of bouldering problems. Numbers in the grading scale are preceeded by a "V". To extend the grading scale into easier routes, VB, V0- and V0+ have been added.</p>
 <p><b>Fontainebleau</b>: First used to classify the difficulty of bouldering problems in the boulder strewn forests near the French town of Fontainebleau, the Fontainebleau (or more commonly Font) scale is now widely used throughout Europe.</p>

<%--    
    <p>Here is a table to help you convert between Australia, USA, France, UK Tech and UK climbing grade systems.</p>

    <img src="/images/specialpages/GradeChart(2).jpg" />
--%>

</asp:Content>
