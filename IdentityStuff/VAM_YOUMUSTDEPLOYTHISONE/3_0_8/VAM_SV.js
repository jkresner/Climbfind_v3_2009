// Copyright 2003 - 2007 Peter L. Blum, All Rights Reserved, www.PeterBlum.com
// Professional Validation And More v3.0.8


function VAM_EvalDiffCond(pCO)

function VAM_EvalCountChecksCond(pCO)
vDone = true;
}
pCO.Count = vCnt; return ((pCO.Min <= vCnt) && ((pCO.Max == 0) || (pCO.Max >= vCnt))) ? 1 : 0;

function VAM_EvalCountSelsCond(pCO)
return -1;

function VAM_EvalCountTrueCond(pCO)
pCO.Count = vCnt; if (!vCanEval)

function VAM_EvalCCNCond(pCO)
return pCO.IBT;
{
var vFd = false; for (var vI = 0; (vI < pCO.PfxByLen.length) && !vFd; vI++)
if (pCO.PfxByLen[vI].Len == vLen)
if (!vFd) 
return 0;
var vT = 0; var vAN = true; for (var vI = vLen - 1; vI >= 0; vI--)
vT += vD;
{
return vT % 10 == 0 ? 1 : 0;

function VAM_EvalABARtNumCond(pCO)
return pCO.IBT;
return 0;
if (vT == 0)

function VAM_InitDupEntryCond(pCO, pAO)

function VAM_EvalDupEntryCond(pCO)
vV = VAM_GetSelIdx(vC.ID, vC.GetSelIdx);
vV = vV.toUpperCase();
for (var vJ = 0; vJ < vVals.length; vJ++)
if ((vTM && (!pCO.IU || (vV != pCO.UTxt))) 
||

if (vVals[vJ] == vV) 
{
vVals[vVals.length] = vV;
return 1;

function VAM_EvalSelIdxRngCond(pCO)
return 0;

function VAM_EvalSelIdxRngCond2(pCO)
var vIdx = VAM_GetChkdLstIdx(pCO.IDToEval, pCO.GetChild);
return 0;

function VAM_EvalBadWordsCond(pCO)
{
return 1;
function VAM_DiffReplToken(pAO, pText)

function VAM_CntSelReplToken(pAO, pText)

function VAM_CntTrueReplToken(pAO, pText)

function VAM_DupEntryReplToken(pAO, pText)

function VAM_BadWordsReplToken(pAO, pText)

function VAM_CntWords(pCO, pText)

var gVAM_CEMActions = null;
if (!vFnd)
gVAM_CEMActions[gVAM_CEMActions.length] = pAO;

function VAM_CEMDoAction()
VAM_CEMDoOneAction(vAO);
} 
} 
function VAM_CEMDoOneAction(pAO)
{ 
vR = 0;
pAO.EMsg = pAO.LdTxt + pAO.EMsg;
break; } 
} 
} 
pAO.CondResult = vR; VAM_DoValidate(pAO, vR);
function VAM_CEMSelErrMsg(pAO)
return pAO.EMsg;

function VAM_GetChkdLstIdx(pFId, pGetChild)
for (var vI = 0; true; vI++)
} 