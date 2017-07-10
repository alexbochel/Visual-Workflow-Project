
// VisualWorkflowDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CVisualWorkflowDlg dialog
class CVisualWorkflowDlg : public CDialogEx
{
// Construction
public:
	CVisualWorkflowDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_VISUALWORKFLOW_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedMain();
	afx_msg void OnBnClickedSetup();
	afx_msg void OnBnClickedUpdate();
	CButton c_Main;
	CButton c_Setup;
	CButton c_Update;
};
