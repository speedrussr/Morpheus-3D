﻿// GUI Animator FREE
// Version: 1.0.1
// Author: Gold Experience Team (http://ge-team.com/pages/unity-3d/)
// Support: geteamdev@gmail.com
// Please direct any bugs/comments/suggestions to support e-mail (geteamdev@gmail.com)

#region Namespaces

	using UnityEngine;
	using System.Collections;

	using UnityEngine.UI;

#endregion

// ######################################################################
// This class shows MoveIn and MoveOut buttons.
// It plays MoveIn animation when user pressed MoveIn button.
// Otherwise, if MoveOut button is pressed the scene will play MoveOut animation.
// ######################################################################

public class Demo : MonoBehaviour {
	

	// ######################################################################
	// MonoBehaviour functions
	// ######################################################################

	#region MonoBehaviour Functions

		private float m_WaitTime		= 4.0f;
		private float m_WaitTimeCount	= 0;
		private bool m_ShowMoveInButton	= true;

		// Use this for initialization
		void Awake () {
			//////////////////////////////////////////////////////////////////////
			// If GUIAnimSystemFREE.Instance.m_AutoAnimation is false, all GEAnim elements in the scene will be controlled by scripts.
			// Otherwise, they will be animated automatically.
			//////////////////////////////////////////////////////////////////////
			if (enabled)
			{
				GUIAnimSystemFREE.Instance.m_GUISpeed = 1.0f;
				GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
			}
		}

		// Use this for initialization
		void Start () {
		}
	
		// Update is called once per frame
		void Update () {

			// Count down timer for MoveIn/MoveOut buttons
			if(m_WaitTimeCount>0 && m_WaitTimeCount<=m_WaitTime)
			{ 
				m_WaitTimeCount -= Time.deltaTime;
				if(m_WaitTimeCount<=0)
				{ 
					m_WaitTimeCount = 0;

					// Switch status of m_ShowMoveInButton
					m_ShowMoveInButton = !m_ShowMoveInButton;
				}
			}	
		}

		void OnGUI()
		{ 
			// Show GUI button when ready
			if(m_WaitTimeCount<= 0)
			{ 
				Rect rect = new Rect((Screen.width-100)/2,(Screen.height-50)/2,100,50);
				// Show MoveIn button
				if(m_ShowMoveInButton==true)
				{ 
					if(GUI.Button(rect, "MoveIn"))
					{ 
						// Play MoveIn animations
						GUIAnimSystemFREE.Instance.MoveIn(this.transform, true);
						m_WaitTimeCount = m_WaitTime;
					}
				}
				// Show MoveOut button
				else
				{ 
					if(GUI.Button(rect, "MoveOut"))
					{ 
						// Play MoveOut animations
						GUIAnimSystemFREE.Instance.MoveOut(this.transform, true);
						m_WaitTimeCount = m_WaitTime;
					}
				}	
			}
		}

	#endregion //MonoBehaviour Functions
}
