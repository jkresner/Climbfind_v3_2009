// Copyright 2003 - 2007 Peter L. Blum, All Rights Reserved, www.PeterBlum.com
// Professional Validation And More v3.0.9


var gVAM_CBCount = 0;var gVAM_CBLast = 0;function VAM_StartCallback(pVCnt, pFinishDelay, pReattachAll){
function CleanupArray(pL, pUseEmpty, pSetup){if (pL){var vT = new Array;for (var vI = 0; vI < pL.length; vI++){var vFld = VAM_GetById(pL[vI].id); if (vFld) 
{
if (!pSetup || eval("vFld." + pSetup))vT[vT.length] = vFld;}
pL[vI] = null;} 
if (!pUseEmpty && (vT.length == 0))return null;pL = vT;}return pL;} if (window.gVAMDebugAJAX == true) 
{alert("Begin VAM Callback response.");window.gVAMDebugAJAX2 = true; }gVAM_InCallback = true; gVAM_DelayAOs = null; gVAM_DelayedInit = null; gVAM_ReattachAll = pReattachAll;gVAM_CBCount++;if (window.gVAM_VG){gVAM_VG.VCnt = pVCnt;VAM_InitValA();}
if (window.gVAMActions)for (var vI = 0; vI < gVAMActions.length; vI++){var vAO = gVAMActions[vI];if (!vAO)continue;if (vAO.CBDisabled) 
vAO.Enabled = true;if (vAO.ToDel && vAO.ToDel(vAO)){vAO.Enabled = false;vAO.CBDisabled = true;}else if (vAO.VIdx != null) 
gVAM_Vals[vAO.VIdx] = vAO;} 
if (window.gVAM_ValFlds){var vT = new Array;for (var vI = 0; vI < gVAM_ValFlds.length; vI++){var vFld = VAM_GetById(gVAM_ValFlds[vI].id); if (vFld && vFld.ActionIDs) 
vT[vT.length] = vFld;gVAM_ValFlds[vI] = null;} 
gVAM_ValFlds = vT.length > 0 ? vT : null;}
if (window.gVAM_ValSummary){var vT = new Array;for (var vI = 0; vI < gVAM_ValSummary.length; vI++){var vVSO = gVAM_ValSummary[vI];var vFld = VAM_GetById(vVSO.ValSumID); if (vFld) 
vT[vT.length] = vVSO;} 
gVAM_ValSummary = vT.length > 0 ? vT : null;}window.gVAM_SSMsgs = null;gVAM_SOC = CleanupArray(window.gVAM_SOC, true, "VAMSOC");gVAM_GOC = CleanupArray(window.gVAM_GOC, true, "gocDE");gVAM_Hints = CleanupArray(window.gVAM_Hints, true, "VAMHint");gVAM_MSDE = CleanupArray(window.gVAM_MSDE, true, "multiseg");if (window.gVAM_DTTBIds){var vT = new Array;for (var vI = 0; vI < gVAM_DTTBIds.length; vI++){var vFld = VAM_GetById(gVAM_DTTBIds[vI]); if (vFld && vFld.Spin) 
vT[vT.length] = vFld.id;var vBtn = VAM_GetById(gVAM_DTTBIds[vI] + "_Btns");if (vBtn)vBtn.style.visibility = "hidden";} 
gVAM_DTTBIds = (vT.length == 0) ? null : vT;}if (pFinishDelay)window.setTimeout('VAM_FinishCallback(' + pVCnt + ',' + pReattachAll + ');', pFinishDelay); } 

function VAM_CallbackInit(pData, pInitFnc){if (window.gVAMDebugAJAX == true) 
{alert('Callback receiving control data');window.setTimeout("window.gVAMDebugAJAX = true;", 1000);window.gVAMDebugAJAX = false; window.gVAMDebugAJAX2 = true; }switch (pInitFnc){case 0: 
VAM_InitActionCB(pData);break;case 1: 
VAM_AddValSum(pData);break;case 10: 

VAM_InitBtn(pData[0], pData[1], pData[2]);break;case 11: 

VAM_InitLinkBtn(pData[0], pData[1], pData[2]);break;case 12: 

VAM_InitMenuControl(pData[0], pData[1], pData[2], pData[3]);break;case 13: 

VAM_InitLinkMenuControl(pData[0], pData[1], pData[2]);break;case 20: 

VAM_InitKey(pData);break;case 21: 

VAM_InitSOC(pData[0], pData[1]);break;case 22: 

VAM_VWBInit(pData[0], pData[1]);break;case 25: 

VAM_InitMSDE(pData[0], pData[1]);break;case 27: 
VAM_InitSpinner(pData);break;case 28: 
VAM_NoPaste(pData);break;case 30: 

VAM_InitHint(pData);break;case 40: 

var vFnc = new Function(pData[1]);VAM_GOCInitCstmOC(pData[0], vFnc);break;case 100: 
eval(pData);break;}} 

function VAM_CallbackPreInit(pData, pInitFnc){if (!gVAM_DelayedInit)gVAM_DelayedInit = new Array;gVAM_DelayedInit[gVAM_DelayedInit.length] = {Data: pData, Fnc: pInitFnc};} 

var gVAM_DelayedInit = null;function VAM_FinishCallback(pVCnt, pReattachAll){if (pVCnt == null) 
pVCnt = 200; if (gVAM_CBCount == gVAM_CBLast)VAM_StartCallback(pVCnt, 0, pReattachAll);gVAM_CBLast = gVAM_CBCount;if (gVAM_DelayedInit){
if (window.PDP_InitObjects)PDP_InitObjects(false);var vRest = new Array; for (var vI = 0; vI < gVAM_DelayedInit.length; vI++){var vObj = gVAM_DelayedInit[vI];if ((vObj.Fnc == 0) && (vObj.Data.VT == "VAL"))VAM_CallbackInit(vObj.Data, vObj.Fnc);elsevRest[vRest.length] = vObj;} 

var vAutoRun = new Array;var vCalc = false; for (var vI = 0; vI < vRest.length; vI++){var vObj = vRest[vI];VAM_CallbackInit(vObj.Data, vObj.Fnc);if (vObj.Fnc == 0) 
{var vAO = vObj.Data;if (vAO.AutoRun)vAutoRun[vAutoRun.length] = vAO;if (vAO.VT == "CALC")vCalc = true;}} if (vAutoRun.length > 0)for (var vI = 0; vI < vAutoRun.length; vI++){VAM_DoAction(vAutoRun[vI]);} 
if (pReattachAll && gVAMActions){for (var vActnID = 0; vActnID < gVAMActions.length; vActnID++){VAM_InitOneAction(vActnID);}}if (vCalc) 
VAM_CalcAll();}else 
{if (window.VAM_CalcAll)VAM_CalcAll();if (window.VAM_RunAllFSC)VAM_RunAllFSC(false); }VAM_FixAbsPos(true);if (window.VAM_DSBody && window.gVAMSubmitIDs)VAM_DSBody(false);gVAM_DelayedInit = null;if (window.gVAMDebugAJAX2){alert("End VAM Callback response.");window.gVAMDebugAJAX = true; window.gVAMDebugAJAX2 = null;}} 

function VAM_InitActionCB(pAO){if (!window.gVAMActions) 
gVAMActions = new Array();var vFnd = false;var vActnID = 0; for (vActnID = 0; vActnID < gVAMActions.length; vActnID++){if (pAO.CID && (pAO.CID == gVAMActions[vActnID].CID)) 
{vFnd = true;gVAMActions[vActnID] = pAO;break;}}if (!vFnd) 
{vActnID = gVAMActions.length;gVAMActions[gVAMActions.length] = pAO;}VAM_InitOneAction(vActnID);if (pAO.AutoRun || (pAO.VT == "CALC")){if (!window.gVAM_DelayAOs)gVAM_DelayAOs = new Array;gVAM_DelayAOs[gVAM_DelayAOs.length] = pAO;}} 

var gVAM_DelayAOs = null;function VAM_AddValSum(pVSO){if (!window.gVAM_ValSummary)gVAM_ValSummary = new Array;var vFnd = false;var vVSID = 0; for (vVSID = 0; vVSID < gVAM_ValSummary.length; vVSID++){if (pVSO.ValSumID && (pVSO.ValSumID == gVAM_ValSummary[vVSID].ValSumID)) 
{vFnd = true;gVAM_ValSummary[vVSID] = pVSO;break;}}if (!vFnd) 
{vVSID = gVAM_ValSummary.length;gVAM_ValSummary[gVAM_ValSummary.length] = pVSO;}} 

function VAM_ToDel(pAO){if (pAO.ErrFldID && !VAM_GetById(pAO.ErrFldID))return true;if (pAO.Cond && pAO.Cond.ToDel && pAO.Cond.ToDel(pAO.Cond))return true;if (pAO.Enabler && pAO.Enabler.ToDel && pAO.Enabler.ToDel(pAO.Enabler))return true;return false;} 

function VAM_ToDelVal(pAO){if (pAO.ErrFldID != null){pAO.ErrFld = VAM_GetById(pAO.ErrFldID);pAO.ImgErrFld = VAM_GetById(pAO.ErrFldID + "_Img");pAO.TxtErrFld = null; pAO.LnkErrFld = null;}if (VAM_ToDel(pAO)) 
return true;return false;} 

function VAM_ToDelCalc(pAO){function ToDelExp(pExp){for (var vI = 0; vI < pExp.length; vI++){var vIC = pExp[vI]; if (vIC.Cond)if (vIC.Cond.ToDel && vIC.Cond.ToDel())return true;if (vIC.LID && !VAM_GetById(vIC.LID))return true;if (vIC.CID && !VAM_GetById(vIC.CID))return true;if (vIC.CalcID && !VAM_GetById(vIC.CalcID))return true;if (vIC.Exp != null) 
if (ToDelExp(vIC.Exp)) 
return true;if (vIC.ExpT != null) 
if (ToDelExp(vIC.ExpT)) 
return true;if (vIC.ExpF != null) 
if (ToDelExp(vIC.ExpF)) 
return true;} 
return false;} 
if (pAO.CID2 && !VAM_GetById(pAO.CID2))return true;if (pAO.SVID && !VAM_GetById(pAO.SVID))return true;if (pAO.Exp && ToDelExp(pAO.Exp))return true;if (VAM_ToDel(pAO)) 
return true;return false;} 

function VAM_ToDelFSC(pAO){pAO.ChgFld = VAM_GetById(pAO.IDToChg); if (VAM_ToDel(pAO)) 
return true;return false;} 

function VAM_ToDelMultiA(pAO){var vR = false;if (pAO.Actions) 
for (var vI = 0; vI < pAO.Actions.length; vI++){var vAO = pAO.Actions[vI];if (vAO.ToDel && vAO.ToDel(pAO))vR = true;}if (vR)return true;if (VAM_ToDel(pAO)) 
return true;return false;} 

function VAM_ToDelCond(pCO){if (pCO.IDToEval && !VAM_GetById(pCO.IDToEval))return true;if (pCO.IDToEval2 && !VAM_GetById(pCO.IDToEval2))return true;return false;} 

function VAM_ToDelMultiCond(pCO){var vR = false;if (pCO.Conds) 
for (var vI = 0; vI < pCO.Conds.length; vI++){var vCO = pCO.Conds[vI];if (vCO.ToDel && vCO.ToDel(vCO)) 
vR = true;}if (vR)return true;return false;} 
