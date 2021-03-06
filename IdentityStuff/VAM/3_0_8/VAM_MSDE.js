// Copyright 2003 - 2007 Peter L. Blum, All Rights Reserved, www.PeterBlum.com
// Professional Validation And More v3.0.8


function VAM_InitCondMSDE(pCO, pAO){VAM_InitOneFldCond(pCO, pAO);} 

function VAM_EvalCondMSDE(pCO){var vE = true; var vV = true; var vID = pCO.IDToEval; var vMS = VAM_GetById(pCO.IDToEval).multiseg;for (vI = 0; (vV || vE) && (vI < vMS.length); vI++){var vT = VAM_GetById(vID + "_" + vMS[vI].SN);var vO = vMS[vI]; var vL = VAM_Trim(vT.value).length; if (vE && (vL != 0)) 
vE = false;if (vV) 
{if (vO.Rq && (vL == 0)) 
vV = false;else if (vL > 0){vL = vT.value.length; if (vL < vO.Min)vV = false;else if (vO.RE != null)vV = vO.RE.test(vT.value);}} 
} if (vE) 
return pCO.IBT; elsereturn vV ? 1 : 0;} 

var gVAM_MSDE = null;function VAM_InitMSDE(pId, pMS){var vFld = VAM_GetById(pId);if (!vFld) 
return;if (vFld.multiseg)return;vFld.multiseg = pMS;if (!gVAM_MSDE) 
{gVAM_MSDE = new Array;if (window.attachEvent) 
window.attachEvent("onunload", VAM_DisposeMSDE);}
gVAM_MSDE[gVAM_MSDE.length] = vFld;for (var vI = 0; vI < pMS.length; vI++){var vT = VAM_GetById(pId + "_" + pMS[vI].SN);VAM_GOCInit(vFld, vT);vT.SvVal = vT.value; vT.MSDE = vFld; if (vT.tagName == "SELECT") 
{vT.onfocus = new Function("VAM_GOCSet(this, true, null);"); vT.onchange = new Function("VAM_GOCSet(this, true, true);"); vT.onblur = new Function("VAM_GOCSet(this, false, null);"); }
} } 

function VAM_DisposeMSDE(){if (gVAM_MSDE)for (var vI = 0; vI < gVAM_MSDE.length; vI++){var vF = gVAM_MSDE[vI];for (var vK = 0; vK < vF.multiseg.length; vK++){var vT = VAM_GetById(vF.id + "_" + vF.multiseg[vK].SN);vT.MSDE = null;vT.onfocus = null; vT.onchange = null; vT.onblur = null; } 
vF.multiseg = null;}gVAM_MSDE = null;} 

function VAM_GetTextMSDE(pId){var vR = ""; var vB = true; var vMS = VAM_GetById(pId).multiseg;for (vI = 0; vI < vMS.length; vI++){var vT = VAM_GetById(pId + "_" + vMS[vI].SN);var vO = vMS[vI];var vE = VAM_Trim(vT.value).length == 0;if (vB && !vE)vB = false;if (!vO.NTB || !vE) 
vR = vR + vO.TB;if (vE)vR = vR + vO.TWB; elsevR = vR + vT.value;if (!vO.NTA || !vE) 
vR = vR + vO.TA;} 
return vB ? "" : vR;} 

function VAM_GetChildMSDE(pFldID, pIdx, pMd){var vID = null;if (pIdx == 0) 
vID = pFldID;else if (pMd == 0) 
{var vMS = VAM_GetById(pFldID).multiseg;if (vMS.length >= pIdx)vID = pFldID + "_" + vMS[pIdx - 1].SN; }if (vID)return VAM_GetById(vID);return null;} 

function VAM_ValMSDE(pId){var vIsV = true; VAM_FieldChanged(pId); var vFld = VAM_GetById(pId);if (VAM_IsValid(pId) == false)vIsV = false;var vMS = vFld.multiseg;for (vI = 0; vI < vMS.length; vI++){var vSId = pId + "_" + vMS[vI].SN;VAM_FieldChanged(vSId);if (VAM_IsValid(vSId) == false)vIsV = false;}return vIsV;} 

function VAM_ClearMSDE(pId){var vMS = VAM_GetById(pId).multiseg;for (vI = 0; vI < vMS.length; vI++){var vT = VAM_GetById(pId + "_" + vMS[vI].SN);vT.value = "";}} 

function VAM_SaveMSDE(pId){var vMS = VAM_GetById(pId).multiseg;for (vI = 0; vI < vMS.length; vI++){var vT = VAM_GetById(pId + "_" + vMS[vI].SN);vT.SvVal = vT.value;}} 

function VAM_RestoreMSDE(pId){var vMS = VAM_GetById(pId).multiseg;for (vI = 0; vI < vMS.length; vI++){var vT = VAM_GetById(pId + "_" + vMS[vI].SN);if (vT.SvVal != null)vT.value = vT.SvVal;}} 