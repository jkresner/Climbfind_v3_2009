// Copyright 2003 - 2007 Peter L. Blum, All Rights Reserved, www.PeterBlum.com
// Professional Validation And More v3.0.9


var gVAM_CBCount = 0;
function CleanupArray(pL, pUseEmpty, pSetup)
{
if (!pSetup || eval("vFld." + pSetup))
pL[vI] = null;
if (!pUseEmpty && (vT.length == 0))
{
if (window.gVAMActions)
vAO.Enabled = true;
gVAM_Vals[vAO.VIdx] = vAO;
if (window.gVAM_ValFlds)
vT[vT.length] = vFld;
gVAM_ValFlds = vT.length > 0 ? vT : null;
if (window.gVAM_ValSummary)
vT[vT.length] = vVSO;
gVAM_ValSummary = vT.length > 0 ? vT : null;
vT[vT.length] = vFld.id;
gVAM_DTTBIds = (vT.length == 0) ? null : vT;

function VAM_CallbackInit(pData, pInitFnc)
{
VAM_InitActionCB(pData);
VAM_AddValSum(pData);

VAM_InitBtn(pData[0], pData[1], pData[2]);

VAM_InitLinkBtn(pData[0], pData[1], pData[2]);

VAM_InitMenuControl(pData[0], pData[1], pData[2], pData[3]);

VAM_InitLinkMenuControl(pData[0], pData[1], pData[2]);

VAM_InitKey(pData);

VAM_InitSOC(pData[0], pData[1]);

VAM_VWBInit(pData[0], pData[1]);

VAM_InitMSDE(pData[0], pData[1]);
VAM_InitSpinner(pData);
VAM_NoPaste(pData);

VAM_InitHint(pData);

var vFnc = new Function(pData[1]);
eval(pData);

function VAM_CallbackPreInit(pData, pInitFnc)

var gVAM_DelayedInit = null;
pVCnt = 200; if (gVAM_CBCount == gVAM_CBLast)
if (window.PDP_InitObjects)

var vAutoRun = new Array;
{
if (pReattachAll && gVAMActions)
VAM_CalcAll();
{

function VAM_InitActionCB(pAO)
gVAMActions = new Array();
{
{

var gVAM_DelayAOs = null;
{
{

function VAM_ToDel(pAO)

function VAM_ToDelVal(pAO)
return true;

function VAM_ToDelCalc(pAO)
if (ToDelExp(vIC.Exp)) 
return true;
if (ToDelExp(vIC.ExpT)) 
return true;
if (ToDelExp(vIC.ExpF)) 
return true;
return false;
if (pAO.CID2 && !VAM_GetById(pAO.CID2))
return true;

function VAM_ToDelFSC(pAO)
return true;

function VAM_ToDelMultiA(pAO)
for (var vI = 0; vI < pAO.Actions.length; vI++)
return true;

function VAM_ToDelCond(pCO)

function VAM_ToDelMultiCond(pCO)
for (var vI = 0; vI < pCO.Conds.length; vI++)
vR = true;