//using ICSharpCode.TextEditor;
//using ICSharpCode.TextEditor.Document;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace hmitype
{
	public class textmsg
	{
		public Myapp_inf Myapp;

		public mpage dpage;

		public bool textevent = false;

		private TextEditorControl textBox1 = null;

		private List<textmessage_type> messagecom = new List<textmessage_type>();

		private List<textmessage_type> messageva = new List<textmessage_type>();

		private List<listmessage_type> findmessage = new List<listmessage_type>();

		private int ListFormWidth = 202;

		private TopMessage Topm1;

		public ListMessage Listm1;

		private byte showstate = 0;

		private int showline = -1;

		private int KeyTextoffset;

		private int KeyTextlenth;

		private bool timerlock = false;

		private Point mousemovepos = new Point(0, 0);

		private Timer timershow = null;

		private string Keywordstr = " ,(){}[]'\"&|\r\n";

		private int messageid = 0;

		public void CloseMe()
		{
			this.textevent = false;
			if (this.Topm1 != null)
			{
				this.Topm1.Close();
			}
			if (this.Topm1 != null)
			{
				this.Topm1.Dispose();
			}
			this.Topm1 = null;
			if (this.Listm1 != null)
			{
				this.Listm1.Close();
			}
			if (this.Listm1 != null)
			{
				this.Listm1.Dispose();
			}
			this.Listm1 = null;
		}

		public textmsg(TextEditorControl text1, int codemessageindex)
		{
			try
			{
				this.messageid = codemessageindex;
				this.closemessageshow();
				if (this.timershow == null)
				{
					this.timershow = new Timer();
					this.timershow.Enabled = false;
					this.timershow.Interval = 50;
					this.timershow.Tick += new EventHandler(this.timershow_Tick);
				}
				this.timershow.Enabled = false;
				this.DisptextBox();
				this.inttextBox(text1);
				if (this.messagecom.Count == 0)
				{
					this.messageinit();
				}
				if (this.Listm1 == null)
				{
					this.Listm1 = new ListMessage();
					this.Listm1.Width = this.ListFormWidth;
					this.Listm1.Height = 20;
					this.Listm1.Show();
					ListMessage expr_162 = this.Listm1;
					expr_162.KeyEnter = (EventHandler)Delegate.Combine(expr_162.KeyEnter, new EventHandler(this.OnKeyenter));
				}
				if (this.Topm1 == null)
				{
					this.Topm1 = new TopMessage();
					this.Topm1.Width = 10;
					this.Topm1.Height = 10;
					this.Topm1.Show();
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void timershow_Tick(object sender, EventArgs e)
		{
			try
			{
				this.timerlock = true;
				this.timershow.Enabled = false;
				this.KeywordoffsetChange();
				this.textBox1.Focus();
				this.timerlock = false;
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void inttextBox(TextEditorControl text1)
		{
			try
			{
               
         

                this.textBox1 = text1;
				this.textBox1.Document.TextKeyPress += new DocumentEventHandler(this.Document_TextKeyPress);
				this.textBox1.Document.DocumentChanged += new DocumentEventHandler(this.DocumentChanged);
				this.textBox1.Document.TextArea.Caret.PositionChanged += new EventHandler(this.DocumentCaretPositionChanged);
				this.textBox1.Document.TextArea.MouseMove += new MouseEventHandler(this.DocumentMouseMove);
				this.textBox1.Document.TextArea.MouseLeave += new EventHandler(this.DocumentMouseLeave);
               
             this.textBox1.Document.TextArea.MotherTextAreaControl.VScrollBar.ValueChanged += new EventHandler(this.DocumentScroll);
				this.textBox1.Document.TextArea.MotherTextAreaControl.HScrollBar.ValueChanged += new EventHandler(this.DocumentScroll);
				this.textBox1.Document.TextArea.GotFocus += new EventHandler(this.ThisGotFouce);
				this.textBox1.Document.TextArea.LostFocus += new EventHandler(this.ThisLostFouce);
				this.textBox1.Document.TextArea.Resize += new EventHandler(this.textresize);
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void DisptextBox()
		{
			try
			{
				if (this.textBox1 != null)
				{
					this.textBox1.Document.TextKeyPress -= new DocumentEventHandler(this.Document_TextKeyPress);
					this.textBox1.Document.DocumentChanged -= new DocumentEventHandler(this.DocumentChanged);
					this.textBox1.Document.TextArea.Caret.PositionChanged -= new EventHandler(this.DocumentCaretPositionChanged);
					this.textBox1.Document.TextArea.MouseMove -= new MouseEventHandler(this.DocumentMouseMove);
					this.textBox1.Document.TextArea.MouseLeave -= new EventHandler(this.DocumentMouseLeave);
					this.textBox1.Document.TextArea.MotherTextAreaControl.VScrollBar.ValueChanged -= new EventHandler(this.DocumentScroll);
					this.textBox1.Document.TextArea.MotherTextAreaControl.HScrollBar.ValueChanged -= new EventHandler(this.DocumentScroll);
					this.textBox1.Document.TextArea.GotFocus -= new EventHandler(this.ThisGotFouce);
					this.textBox1.Document.TextArea.LostFocus -= new EventHandler(this.ThisLostFouce);
					this.textBox1 = null;
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void Document_TextKeyPress(object sender, DocumentEventArgs e)
		{
			try
			{
				if (this.textevent)
				{
					Keys keys = (Keys)sender;
					if (this.Listm1 != null && this.Listm1.vis)
					{
						if (keys == Keys.Return || keys == Keys.Up || keys == Keys.Down || keys == Keys.Left || keys == Keys.Right || keys == Keys.Escape)
						{
							this.KeySendPress(keys);
							e.TextCancle = true;
						}
					}
					else if (this.Topm1 != null && this.Topm1.vis)
					{
						if (keys == Keys.Escape)
						{
							this.Topm1.vis = false;
							e.TextCancle = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void DocumentChanged(object sender, DocumentEventArgs e)
		{
			try
			{
				if (this.textevent)
				{
					while (this.timerlock)
					{
					}
					this.timershow.Enabled = false;
					this.timershow.Interval = 50;
					this.timershow.Enabled = true;
					this.showstate = 0;
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void DocumentScroll(object sender, EventArgs e)
		{
			if (this.textevent)
			{
				this.closemessageshow();
			}
		}

		private void DocumentMouseLeave(object sender, EventArgs e)
		{
			if (this.textevent)
			{
				if (this.showstate == 2 && this.Topm1.vis)
				{
					while (this.timerlock)
					{
					}
					this.timershow.Enabled = false;
					this.closemessageshow();
				}
			}
		}

		private void DocumentMouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.textevent)
				{
					if (this.textBox1.Document.TextArea.Focused)
					{
						int num = e.X - this.mousemovepos.X;
						int num2 = e.Y - this.mousemovepos.Y;
						if (num > 3 || num < -3 || num2 > 3 || num2 < -3)
						{
							this.mousemovepos = e.Location;
							if (!this.Listm1.vis)
							{
								if (!this.Topm1.vis || this.showstate == 2)
								{
									while (this.timerlock)
									{
									}
									this.timershow.Enabled = false;
									this.timershow.Interval = 500;
									this.timershow.Enabled = true;
									this.showstate = 2;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void DocumentCaretPositionChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.textevent)
				{
					if (!this.timershow.Enabled || this.showstate != 0)
					{
						if (this.Topm1.vis && !this.Listm1.vis && this.showstate == 1)
						{
							while (this.timerlock)
							{
							}
							this.timershow.Enabled = false;
							this.timershow.Interval = 50;
							this.timershow.Enabled = true;
							this.showstate = 1;
						}
						else
						{
							this.closemessageshow();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private bool isoffsettrue(int offset)
		{
			bool result;
			if (offset >= this.textBox1.Text.Length)
			{
				result = false;
			}
			else
			{
				int lineNumberForOffset = this.textBox1.Document.GetLineNumberForOffset(offset);
				int offset2 = this.textBox1.Document.GetLineSegment(lineNumberForOffset).Offset;
				string text = this.textBox1.Document.GetText(offset2, offset - offset2).Trim();
				int num = 0;
				for (int i = 0; i < text.Length; i++)
				{
					string a = text.Substring(i, 1);
					if (a == "\"")
					{
						if (i == 0 || text.Substring(i - 1, 1) != "\\")
						{
							if (num == 0)
							{
								num = 1;
							}
							else
							{
								num = 0;
							}
						}
					}
					else if (a == "/")
					{
						if (num == 0 && i > 0 && text.Substring(i - 1, 1) == "/")
						{
							result = false;
							return result;
						}
					}
				}
				result = (num == 0);
			}
			return result;
		}

		private string getkeywordofoffset(int offset, byte state, ref int thisline, ref bool isnewline)
		{
			string text = "";
			string result;
			try
			{
				isnewline = false;
				if (offset >= this.textBox1.Text.Length || !this.isoffsettrue(offset))
				{
					result = "";
					return result;
				}
				char charAt = this.textBox1.Document.GetCharAt(offset);
				if (charAt == '\r' || charAt == '\n')
				{
					result = "";
					return result;
				}
				thisline = this.textBox1.Document.GetLineNumberForOffset(offset);
				int num;
				if (state == 0 || state == 2)
				{
					if (Strmake.Strmake_IsAttendbyte((byte)charAt) == 1 || this.Keywordstr.Contains(charAt))
					{
						result = "";
						return result;
					}
					num = offset;
					while (Strmake.Strmake_IsAttendbyte((byte)charAt) != 1 && !this.Keywordstr.Contains(charAt))
					{
						num--;
						if (num < 0)
						{
							break;
						}
						charAt = this.textBox1.Document.GetCharAt(num);
					}
					num++;
					int offset2 = this.textBox1.Document.GetLineSegment(thisline).Offset;
					if (num == offset2 || this.textBox1.Document.GetText(offset2, num - offset2).Trim() == "")
					{
						isnewline = true;
					}
				}
				else
				{
					isnewline = true;
					num = this.textBox1.Document.GetLineSegment(thisline).Offset;
				}
				int num2;
				if (state == 0 || state == 1)
				{
					num2 = offset;
					if (state == 0)
					{
						int num3 = num2 + 1;
						if (num3 < this.textBox1.Text.Length)
						{
							charAt = this.textBox1.Document.GetCharAt(num3);
							if (Strmake.Strmake_IsAttendbyte((byte)charAt) != 1 && !this.Keywordstr.Contains(charAt))
							{
								result = "";
								return result;
							}
						}
					}
				}
				else
				{
					charAt = this.textBox1.Document.GetCharAt(offset);
					num2 = offset;
					while (Strmake.Strmake_IsAttendbyte((byte)charAt) != 1 && !this.Keywordstr.Contains(charAt))
					{
						num2++;
						if (num2 >= this.textBox1.Text.Length)
						{
							break;
						}
						charAt = this.textBox1.Document.GetCharAt(num2);
					}
					num2--;
				}
				if (num2 < num)
				{
					result = "";
					return result;
				}
				if (num2 - num > 99)
				{
					result = "";
					return result;
				}
				if (text.Contains("\r") || text.Contains("\n"))
				{
					text = "";
				}
				text = this.textBox1.Document.GetText(num, num2 - num + 1).TrimStart(new char[]
				{
					' '
				});
				this.KeyTextoffset = num;
				this.KeyTextlenth = num2 - num + 1;
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
			result = text;
			return result;
		}

		private void KeywordoffsetChange()
		{
			bool isnewline = false;
			string str = "";
			int thisline = -1;
			try
			{
				if (datasize.codemessage[this.messageid].allen == 1)
				{
					int num;
					Point point;
					if (this.showstate == 2)
					{
						Point logicalPosition = this.textBox1.Document.TextArea.TextView.GetLogicalPosition(this.mousemovepos.X - this.textBox1.Document.TextArea.TextView.DrawingPosition.X, this.mousemovepos.Y - this.textBox1.Document.TextArea.TextView.DrawingPosition.Y);
						if (logicalPosition.Y >= this.textBox1.Document.TotalNumberOfLines)
						{
							this.closemessageshow();
							return;
						}
						LineSegment lineSegment = this.textBox1.Document.GetLineSegment(logicalPosition.Y);
						if (logicalPosition.X > lineSegment.Length)
						{
							this.closemessageshow();
							return;
						}
						num = Math.Min(this.textBox1.Document.TextLength, lineSegment.Offset + logicalPosition.X);
						point = this.mousemovepos;
						point.Y += this.textBox1.Font.Height / 2 + 2;
					}
					else
					{
						num = this.textBox1.Document.TextArea.Caret.Offset;
						point = this.textBox1.Document.TextArea.Caret.ScreenPosition;
						point.Y += this.textBox1.Font.Height + 2;
					}
					point = this.textBox1.PointToScreen(point);
					int num2 = num - 1;
					if (num2 >= this.textBox1.Text.Length)
					{
						num2 = this.textBox1.Text.Length - 1;
					}
					if (num2 > -1)
					{
						char charAt = this.textBox1.Document.GetCharAt(num2);
						if (this.showstate == 0 && (charAt == ' ' || charAt == ','))
						{
							this.showstate = 1;
						}
						if (this.showstate == 0 && datasize.codemessage[this.messageid].keyword != 1)
						{
							return;
						}
						if (this.showstate == 1 && datasize.codemessage[this.messageid].comshow != 1)
						{
							return;
						}
						if (this.showstate == 2 && datasize.codemessage[this.messageid].mouseshow != 1)
						{
							return;
						}
						str = this.getkeywordofoffset(num2, this.showstate, ref thisline, ref isnewline);
					}
					this.KeyWordChange(str, this.dpage, point, isnewline, thisline, this.showstate);
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void OnKeyenter(object sender, EventArgs e)
		{
			try
			{
				string value = ((listmessage_type)sender).Value;
				if (this.KeyTextoffset + this.KeyTextlenth <= this.textBox1.Document.TextLength)
				{
					this.textevent = false;
					this.textBox1.Document.Replace(this.KeyTextoffset, this.KeyTextlenth, value);
					this.textBox1.Document.TextArea.Caret.Position = this.textBox1.Document.OffsetToPosition(this.KeyTextoffset + value.Length);
					this.textBox1.Focus();
					this.textevent = true;
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		public void closemessageshow()
		{
			try
			{
				if (this.Topm1 != null)
				{
					this.Topm1.vis = false;
				}
				if (this.Listm1 != null)
				{
					this.Listm1.vis = false;
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private void messageinit()
		{
			try
			{
				this.messagecom.Clear();
				string str = (datasize.Language == 0) ? (Application.StartupPath + "\\ch") : (Application.StartupPath + "\\en");
				str = str + this.messageid.ToString() + "_";
				string path = str + "com.bin";
				string path2 = str + "va.bin";
				StreamReader streamReader = new StreamReader(path);
				byte[] array = new byte[streamReader.BaseStream.Length - 1L];
				streamReader.BaseStream.Position = 1L;
				streamReader.BaseStream.Read(array, 0, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					byte[] expr_B5_cp_0 = array;
					int expr_B5_cp_1 = i;
					expr_B5_cp_0[expr_B5_cp_1] ^= 5;
				}
				streamReader.Close();
				string[] array2 = Encoding.GetEncoding("UTF-8").GetString(array).Replace("\r\n", "\r").Split(new char[]
				{
					'\r'
				});
				string[] array3 = array2;
				for (int j = 0; j < array3.Length; j++)
				{
					string text = array3[j];
					string text2 = text.Trim();
					if (text2.Length > 0)
					{
						string[] array4 = text2.Split(new char[]
						{
							'|'
						});
						textmessage_type item = new textmessage_type
						{
							name = "",
							zhushi = ""
						};
						item.lei = 0;
						item.name = array4[0].Trim();
						string[] array5 = item.name.Split(new char[]
						{
							'@'
						});
						item.name = array5[0];
						if (array5.Length > 1)
						{
							item.zhushi = array5[1];
						}
						if (array4.Length > 1)
						{
							string text3 = text2.Substring(array4[0].Length + 1, text2.Length - array4[0].Length - 1);
							string[] array6 = text3.Split(new char[]
							{
								'|'
							});
							item.comcans = new comcan_type[array6.Length];
							for (int i = 0; i < array6.Length; i++)
							{
								string[] array7 = array6[i].Split(new char[]
								{
									'@'
								});
								item.comcans[i].canname = array7[0];
								if (array7.Length > 1)
								{
									item.comcans[i].zhushi = array6[i].Substring(array7[0].Length + 1, array6[i].Length - array7[0].Length - 1);
								}
							}
						}
						this.messagecom.Add(item);
					}
				}
				streamReader = new StreamReader(path2);
				array = new byte[streamReader.BaseStream.Length - 1L];
				streamReader.BaseStream.Position = 1L;
				streamReader.BaseStream.Read(array, 0, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					byte[] expr_363_cp_0 = array;
					int expr_363_cp_1 = i;
					expr_363_cp_0[expr_363_cp_1] ^= 5;
				}
				streamReader.Close();
				streamReader.Dispose();
				array2 = Encoding.GetEncoding("UTF-8").GetString(array).Replace("\r\n", "\r").Split(new char[]
				{
					'\r'
				});
				this.messageva.Clear();
				array3 = array2;
				for (int j = 0; j < array3.Length; j++)
				{
					string text = array3[j];
					string text2 = text.Trim();
					if (text2.Length > 0)
					{
						string[] array4 = text2.Split(new char[]
						{
							'|'
						});
						textmessage_type item = new textmessage_type
						{
							name = "",
							zhushi = ""
						};
						item.lei = 1;
						item.name = array4[0].Trim();
						string[] array5 = item.name.Split(new char[]
						{
							'@'
						});
						item.name = array5[0];
						if (array5.Length > 1)
						{
							item.zhushi = array5[1];
						}
						this.messageva.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		private int getcommessageindex(string str)
		{
			int result;
			for (int i = 0; i < this.messagecom.Count; i++)
			{
				if (str == this.messagecom[i].name)
				{
					result = i;
					return result;
				}
			}
			result = -1;
			return result;
		}

		private int getvamessageindex(string str)
		{
			int result;
			for (int i = 0; i < this.messageva.Count; i++)
			{
				if (str == this.messageva[i].name)
				{
					result = i;
					return result;
				}
			}
			result = -1;
			return result;
		}

		private bool CheckComShow(string str, Point point, int state)
		{
			bool result;
			try
			{
				int num = -1;
				bool flag = false;
				int i = 0;
				string[] array = str.Split(new char[]
				{
					' '
				});
				if (state == 2 && array.Length > 1)
				{
					result = false;
					return result;
				}
				int num2 = this.getcommessageindex(array[0]);
				if (num2 > -1)
				{
					if (array.Length > 1)
					{
						num++;
						while (i < array[1].Length)
						{
							string a = array[1].Substring(i, 1);
							if (a == "\"")
							{
								if (i == 0)
								{
									flag = !flag;
								}
								else if (array[1].Substring(i - 1, 1) != "\\")
								{
									flag = !flag;
								}
							}
							else if (!flag && a == ",")
							{
								num++;
							}
							i++;
						}
					}
					textmessage_type tm = this.messagecom[num2];
					this.Topm1.Showstring(tm, num, point, 0, 0);
					result = true;
					return result;
				}
				if (state == 2)
				{
					num2 = this.getvamessageindex(array[0]);
					if (num2 > -1)
					{
						textmessage_type tm = this.messageva[num2];
						this.Topm1.Showstring(tm, -1, point, 0, 0);
						result = true;
						return result;
					}
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
			result = false;
			return result;
		}

		private bool CheckKewordShow(string str, mpage dpage, Point point, bool isnewline)
		{
			bool result = false;
			List<matt> list = new List<matt>();
			try
			{
				this.findmessage.Clear();
				if (!str.Contains("["))
				{
					string[] array = str.Split(new char[]
					{
						'.'
					});
					if (array.Length == 1)
					{
						if (isnewline)
						{
							for (int i = 0; i < this.messagecom.Count; i++)
							{
								if (str.Length <= this.messagecom[i].name.Length)
								{
									if (this.messagecom[i].name.Substring(0, str.Length) == str)
									{
										this.findmessage.Add(new listmessage_type
										{
											imgindex = this.messagecom[i].lei,
											Text = this.messagecom[i].name,
											Value = this.messagecom[i].name,
											textmessage = this.messagecom[i]
										});
									}
								}
							}
						}
						for (int i = 0; i < this.messageva.Count; i++)
						{
							if (str.Length <= this.messageva[i].name.Length)
							{
								if (this.messageva[i].name.Substring(0, str.Length) == str)
								{
									this.findmessage.Add(new listmessage_type
									{
										imgindex = this.messageva[i].lei,
										Text = this.messageva[i].name,
										Value = this.messageva[i].name,
										textmessage = this.messageva[i]
									});
								}
							}
						}
						for (int i = 0; i < this.Myapp.pages.Count; i++)
						{
							if (str.Length <= this.Myapp.pages[i].pagename.Length)
							{
								if (this.Myapp.pages[i].pagename.Substring(0, str.Length) == str)
								{
									this.findmessage.Add(new listmessage_type
									{
										imgindex = 2,
										Text = this.Myapp.pages[i].pagename,
										Value = this.Myapp.pages[i].pagename,
										textmessage = new textmessage_type
										{
											lei = 2,
											zhushi = "页面".Language()
										}
									});
								}
							}
						}
						for (int i = 1; i < dpage.objs.Count; i++)
						{
							if (str.Length <= dpage.objs[i].objname.Length)
							{
								if (dpage.objs[i].objname.Substring(0, str.Length) == str)
								{
									this.findmessage.Add(new listmessage_type
									{
										imgindex = 3,
										Text = dpage.objs[i].objname,
										Value = dpage.objs[i].objname,
										textmessage = new textmessage_type
										{
											lei = 3,
											zhushi = "控件".Language() + ":" + dpage.objs[i].atts[0].zhushi.Getstring(datasize.Myencoding).Split(new char[]
											{
												'-'
											})[0]
										}
									});
								}
							}
						}
					}
					else if (array.Length == 2)
					{
						int num = dpage.Getobjid(array[0]);
						if (num < 65535)
						{
							list = dpage.objs[num].GetAllatts();
							foreach (matt current in list)
							{
								string text = current.name.Getstring(datasize.Myencoding);
								if (array[1] == "")
								{
									this.findmessage.Add(new listmessage_type
									{
										imgindex = 4,
										Text = text,
										Value = array[0] + "." + text,
										textmessage = new textmessage_type
										{
											lei = 4,
											zhushi = current.zhushi.Getstring(126)
										},
										xiugaistate = (int)(10 + current.att.isxiugai)
									});
								}
								else if (array[1].Length <= text.Length && text.Substring(0, array[1].Length) == array[1])
								{
									this.findmessage.Add(new listmessage_type
									{
										imgindex = 4,
										Text = text,
										Value = array[0] + "." + text,
										textmessage = new textmessage_type
										{
											lei = 4,
											zhushi = current.zhushi.Getstring(126)
										},
										xiugaistate = (int)(10 + current.att.isxiugai)
									});
								}
							}
						}
						int num2 = dpage.Myapp.Getpagename(array[0]);
						if (num2 < 65535)
						{
							foreach (mobj current2 in dpage.Myapp.pages[num2].objs)
							{
								string text2 = current2.GetattVal_string("vscope");
								if (text2 != null && text2 == "1")
								{
									string text = current2.objname;
									if (array[1] == "")
									{
										this.findmessage.Add(new listmessage_type
										{
											imgindex = 3,
											Text = text,
											Value = array[0] + "." + text,
											textmessage = new textmessage_type
											{
												lei = 3,
												zhushi = "控件".Language() + ":" + current2.atts[0].zhushi.Getstring(datasize.Myencoding).Split(new char[]
												{
													'-'
												})[0]
											}
										});
									}
									else if (array[1].Length <= text.Length && text.Substring(0, array[1].Length) == array[1])
									{
										this.findmessage.Add(new listmessage_type
										{
											imgindex = 3,
											Text = text,
											Value = array[0] + "." + text,
											textmessage = new textmessage_type
											{
												lei = 3,
												zhushi = "控件".Language() + ":" + current2.atts[0].zhushi.Getstring(datasize.Myencoding).Split(new char[]
												{
													'-'
												})[0]
											}
										});
									}
								}
							}
						}
					}
					else if (array.Length == 3)
					{
						int num2 = dpage.Myapp.Getpagename(array[0]);
						if (num2 < 65535)
						{
							int num = dpage.Myapp.pages[num2].Getobjid(array[1]);
							if (num < 65535)
							{
								list = dpage.Myapp.pages[num2].objs[num].GetAllatts();
								foreach (matt current in list)
								{
									string text = current.name.Getstring(datasize.Myencoding);
									if (array[2] == "")
									{
										this.findmessage.Add(new listmessage_type
										{
											imgindex = 4,
											Text = text,
											Value = string.Concat(new string[]
											{
												array[0],
												".",
												array[1],
												".",
												text
											}),
											textmessage = new textmessage_type
											{
												lei = 4,
												zhushi = current.zhushi.Getstring(126)
											},
											xiugaistate = (int)(10 + current.att.isxiugai)
										});
									}
									else if (array[2].Length <= text.Length && text.Substring(0, array[2].Length) == array[2])
									{
										this.findmessage.Add(new listmessage_type
										{
											imgindex = 4,
											Text = text,
											Value = string.Concat(new string[]
											{
												array[0],
												".",
												array[1],
												".",
												text
											}),
											textmessage = new textmessage_type
											{
												lei = 4,
												zhushi = current.zhushi.Getstring(126)
											},
											xiugaistate = (int)(10 + current.att.isxiugai)
										});
									}
								}
							}
						}
					}
				}
				this.Listm1.Reftextmessages(this.findmessage, point, 0, 16);
				if (this.findmessage.Count == 0)
				{
					this.Listm1.vis = false;
				}
				result = (this.findmessage.Count != 0);
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
			return result;
		}

		public void KeyWordChange(string str, mpage dpage, Point point, bool isnewline, int thisline, byte state)
		{
			try
			{
				this.showstate = state;
				if (str == null || str == "" || str.Length > 50)
				{
					this.Topm1.vis = false;
					this.Listm1.vis = false;
				}
				else if (state == 1)
				{
					this.Listm1.vis = false;
					if ((!this.Topm1.vis || this.showline == thisline) && this.CheckComShow(str, point, (int)state))
					{
						this.showline = thisline;
					}
					else
					{
						this.Topm1.vis = false;
					}
				}
				else if (state == 2)
				{
					this.Listm1.vis = false;
					if (this.CheckComShow(str, point, (int)state))
					{
						this.showline = thisline;
					}
					else
					{
						this.Topm1.vis = false;
					}
				}
				else
				{
					this.Topm1.vis = false;
					if (this.CheckKewordShow(str, dpage, point, isnewline))
					{
						this.showline = thisline;
					}
				}
			}
			catch (Exception ex)
			{
				MessageOpen.Show(ex.Message);
			}
		}

		public void KeySendPress(Keys keydata)
		{
			if (this.Listm1 != null)
			{
				this.Listm1.OnDialogKey(this, new KeyEventArgs(keydata));
			}
		}

		public void ThisGotFouce(object sender, EventArgs e)
		{
			if (this.Topm1 != null)
			{
				this.Topm1.close_end();
			}
			if (this.Listm1 != null)
			{
				this.Listm1.close_end();
			}
		}

		public void ThisLostFouce(object sender, EventArgs e)
		{
			if (this.Topm1 != null)
			{
				this.Topm1.close_yanshi();
			}
			if (this.Listm1 != null)
			{
				this.Listm1.close_yanshi();
			}
		}

		private void textresize(object sender, EventArgs e)
		{
			this.closemessageshow();
		}
	}
}
