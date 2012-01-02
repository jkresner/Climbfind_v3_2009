// Copyright 2003 - 2007 Peter L. Blum, All Rights Reserved, www.PeterBlum.com
// Professional Validation And More v3.0.9


var gVAM_Hints = null;function VAM_InitHint(pHO) 
{if (pHO.GCM) 
{var vDone = false;for (var vI = 0; !vDone; vI++){vFld = pHO.GCM(pHO.CID, vI, 1);if (vFld != null)VAM_InitHintBody(pHO, vFld.id); elsevDone = true;} 
}else 
VAM_InitHintBody(pHO, null);} 

function VAM_InitHintBody(pHO, pFId) 
{if (!pFId)pFId = pHO.CID;var vF = VAM_GetById(pFId);if (!vF) 
return;if (vF.VAMHint)return;vF.VAMHint = 1;if (!gVAM_Hints){gVAM_Hints = new Array;if (window.attachEvent)window.attachEvent("onunload", VAM_DisposeHints);}
gVAM_Hints[gVAM_Hints.length] = vF;vF.Hint = pHO;VAM_AttachEvent(vF, "onfocus", "VAM_ShowHint('" + pFId + "');", false);VAM_AttachEvent(vF, "onblur", "VAM_HideHint('" + pFId + "');", false);if (pHO.ID){pHO.Pnl = VAM_GetById(pHO.ID);pHO.Lbl = VAM_GetById(pHO.ID + "_Text");if (pHO.Lbl == null) 
pHO.Lbl = pHO.Pnl;pHO.Pnl.OrigCss = pHO.Pnl.className;if (pHO.Md){if (pHO.Lbl.innerHTML) 
VAM_SetInnerHTML(pHO.Lbl, "");pHO.SD = pHO.Pnl.style.display; if (pHO.SD == "none") 
pHO.SD = "block";pHO.Pnl.style.visibility = "hidden"; if (pHO.Md == 2)pHO.Pnl.style.display = "none";}}} 

function VAM_DisposeHints(){if (gVAM_Hints){for (var vI = 0; vI < gVAM_Hints.length; vI++){var vF = gVAM_Hints[vI];var vHO = vF.Hint;vHO.Pnl = null;vHO.Lbl = null;}}gVAM_Hints = null;} 

var gVAM_HintCnt = -1;function VAM_ShowHint(pFId){
function AddMsgs(pFld){var vA = pFld.ActionIDs;if (vA){gVAM_HintCnt++; for (var vI = 0; vI < vA.length; vI++){var vAO = gVAMActions[vA[vI]];if (!vAO) 
continue;if ((vAO.VT == "VAL") && !vAO.IsValid && (vAO.HintCnt != gVAM_HintCnt)) 
{var vMsg = VAM_GetErrMsg(vAO);if (vMsg != ""){if (vM != "") 
vM = vM + gVAM_CSG.HSESep;vM = vM + vMsg;if ((gVAM_CSG.HSE == 1) || (gVAM_CSG.HSE == 3)) 
break;}vAO.HintCnt = gVAM_HintCnt; }} } 
} 

var vF = VAM_GetById(pFId);var vHO = vF.Hint;if (!vHO) 
return;if (vHO.SB && (window.status != null))window.status = VAM_StripTags(vHO.H);var vErr = VAM_IsValid(vF) == false; if (!vErr && vF.MSDE) 
vErr = VAM_IsValid(vF.MSDE) == false;if (vHO.E && vErr)return;if (vHO.Pnl)vHO.Pnl.className = vHO.Pnl.OrigCss;var vH = vHO.H; if (vErr &&window.gVAM_CSG && 
gVAM_CSG.HSE) 
{var vM = ""; AddMsgs(vF);if (vF.MSDE) 
AddMsgs(vF.MSDE);if (vM != "") 
{if (gVAM_CSG.HSECss2 != "") 
vM = "<span class='" + gVAM_CSG.HSECss2 + "'>" + vM + "</span>";if (gVAM_CSG.HSE > 2) 
vH = vM;elsevH = vM + gVAM_CSG.HSESep + vH;if (vHO.Pnl && (gVAM_CSG.HSECss != ""))vHO.Pnl.className = gVAM_CSG.HSECss;}} if (vH == "") 
return;if (vHO.CH) 
if (vHO.CH(vF,true,vH,vHO.Pnl)) 
{VAM_FixAbsPos(true);return;}if (vHO.Md && vHO.Lbl) 
{VAM_SetInnerHTML(vHO.Lbl, vH);vHO.Pnl.style.visibility = "inherit";vHO.Pnl.style.display = vHO.SD;VAM_FixAbsPos(true);}} 

function VAM_HideHint(pFId){var vF = VAM_GetById(pFId);var vHO = vF.Hint;if (!vHO) 
return;if (vHO.SB && (window.status != null))window.status = "";if (vHO.CH) 
if (vHO.CH(vF,false,"",vHO.Pnl)) 
{VAM_FixAbsPos(true);return;}if (vHO.Md && vHO.Lbl){VAM_SetInnerHTML(vHO.Lbl, "");vHO.Pnl.style.visibility = "hidden";if (vHO.Md == 2)vHO.Pnl.style.display = "none";VAM_FixAbsPos(true);}} 

function VAM_ChgHint(pFId, pHint){var vF = VAM_GetById(pFId);var vHO = vF.Hint;if (vHO){var vOld = vF.Hint.H;vF.Hint.H = pHint;return vOld;}return null;} 
