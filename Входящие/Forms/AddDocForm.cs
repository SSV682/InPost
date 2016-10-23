using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Data.Classes;
using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.Utils.About;
using DevExpress.XtraBars;
using Data;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.ModelSupport.Implementation;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraReports.Native;
using Входящие.Classes;
using Входящие.InControls;
using StringsF4 = Входящие.Classes.StringsF4;

namespace Входящие.Forms
{
    public partial class AddDocForm : DevExpress.XtraEditors.XtraForm
    {

        //TODO!
        private Документы _документ;
        public PrintMode Print
        {
            get
            {
                return _документ.ПризнакПечати != null && (bool)_документ.ПризнакПечати ? PrintMode.Partially : PrintMode.Full; ;
            }
        }
        private FormF4 _formF4;
        private bool _theAbilityToEditTheDoc;

        public bool TheAbilityToEditTheDoc
        {
            get
            {
                if (GlobalClass.SeesAllDocuments)
                {
                    _theAbilityToEditTheDoc = GlobalClass.CanEdit;
                }
                if(GlobalClass.SeesDocumentsDepartament)
                {
                    var documentThis = _документ.id_исполнителя == GlobalClass.CurrentUser.id_исполнителя;
                    _theAbilityToEditTheDoc = documentThis && GlobalClass.CanEdit;
                }
                if (GlobalClass.SeesTheirDocuments)
                {
                    _theAbilityToEditTheDoc = GlobalClass.CanEdit;
                }
                return _theAbilityToEditTheDoc;
            }
            set { _theAbilityToEditTheDoc = value; }
        }

        public delegate void ChangeTheFate();

        public delegate void UpdateBs();
        public virtual event UpdateBs UpdateBsForJournal;

        public AddDocForm(Документы документ)
        {
            InitializeComponent();
            _документ = документ;
            InitForm();
        }

        private void InitForm()
        {
            _formF4 = new FormF4(_документ, _документ != null && (_документ.ПризнакПечати.HasValue && (bool) _документ.ПризнакПечати));
            Methods.SetInPanelFormF4(panelForm, _formF4);
            AvailabilityOperations();
            InitOfAuthority();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(GlobalClass.CanEdit)
            {
                SaveDocument();
               
            }
            Close();
        }
        
        private void AddDocForm_Load(object sender, EventArgs e)
        {
            //_formF4 = new FormF4(_документ, _документ != null && (_документ.ПризнакПечати.HasValue && (bool)_документ.ПризнакПечати));
            //Methods.SetInPanelFormF4(panelForm, _formF4);
        }
        
        private void passForm_changeHost()
        {
            ChangeHostMethod();
        }
        private void AvailabilityOperations()
        {
            var idOp= _документ.ЖурналОперацийs.OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).Select(p => p.id_операции).FirstOrDefault();
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (idOp != null)
            {
                switch (idOp)
                {
                    case (5)://добавлен в акт
                        {
                            bbi_pass.Enabled = false;
                            bbi_send.Enabled = false;
                            bbi_return.Enabled = false;
                            bbi_in_act.Enabled = false;
                            bbi_hemming.Enabled = false;
                            bbi_remove_from_act.Enabled = true;
                            bbi_re_register.Enabled = false;
                            bbi_store.Enabled = false;
                            bbi_setInventory.Enabled = false;
                            bbi_returnToUnit.Enabled = false;

                            nbi_pass.Enabled = false;
                            nbi_send.Enabled = false;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = false;
                            nbi_hemming.Enabled = false;
                            nbi_reregister.Enabled = false;
                            nbi_store.Enabled = false;
                            nbi_setinventory.Enabled = false;
                            nbi_returntounit.Enabled = false;
                            break;
                        }
                    case (6)://Подшит в дело
                        {
                            bbi_pass.Enabled = false;
                            bbi_send.Enabled = false;
                            bbi_return.Enabled = false;
                            bbi_in_act.Enabled = false;
                            bbi_hemming.Enabled = false;
                            bbi_remove_from_act.Enabled = false;
                            bbi_re_register.Enabled = false;
                            bbi_store.Enabled = false;
                            bbi_setInventory.Enabled = false;
                            bbi_returnToUnit.Enabled = false;

                            nbi_pass.Enabled = false;
                            nbi_send.Enabled = false;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = false;
                            nbi_hemming.Enabled = false;
                            nbi_reregister.Enabled = false;
                            nbi_store.Enabled = false;
                            nbi_setinventory.Enabled = false;
                            nbi_returntounit.Enabled = false;
                            break;
                        }
                    case (3)://Возвращен
                        {
                            bbi_return.Enabled = false;
                            bbi_returnToUnit.Enabled = true;
                            bbi_pass.Enabled = true;
                            bbi_send.Enabled = true;
                            bbi_in_act.Enabled = true;
                            bbi_hemming.Enabled = true;
                            bbi_remove_from_act.Enabled = true;
                            bbi_re_register.Enabled = true;
                            bbi_store.Enabled = true;
                            bbi_setInventory.Enabled = true;

                            nbi_pass.Enabled = true;
                            nbi_send.Enabled = true;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = true;
                            nbi_hemming.Enabled = true;
                            nbi_reregister.Enabled = true;
                            nbi_store.Enabled = true;
                            nbi_setinventory.Enabled = true;
                            nbi_returntounit.Enabled = true;
                            break;
                        }
                    case (2)://Отправлен
                        {
                            bbi_pass.Enabled = false;
                            bbi_send.Enabled = false;
                            bbi_in_act.Enabled = false;
                            bbi_hemming.Enabled = false;
                            bbi_remove_from_act.Enabled = false;
                            bbi_return.Enabled = true;
                            bbi_re_register.Enabled = false;
                            bbi_store.Enabled = false;
                            bbi_setInventory.Enabled = false;
                            bbi_returnToUnit.Enabled = false;

                            nbi_pass.Enabled = false;
                            nbi_send.Enabled = false;
                            nbi_return.Enabled = true;
                            nbi_inact.Enabled = false;
                            nbi_hemming.Enabled = false;
                            nbi_reregister.Enabled = false;
                            nbi_store.Enabled = false;
                            nbi_setinventory.Enabled = false;
                            nbi_returntounit.Enabled = false;
                            break;
                        }
                    case (7)://Удален из акта
                        {
                            bbi_return.Enabled = false;
                            bbi_remove_from_act.Enabled = false;
                            bbi_pass.Enabled = true;
                            bbi_send.Enabled = true;
                            bbi_returnToUnit.Enabled = true;
                            bbi_in_act.Enabled = true;
                            bbi_hemming.Enabled = true;
                            bbi_re_register.Enabled = true;
                            bbi_store.Enabled = true;
                            bbi_setInventory.Enabled = true;

                            nbi_pass.Enabled = true;
                            nbi_send.Enabled = true;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = true;
                            nbi_hemming.Enabled = true;
                            nbi_reregister.Enabled = true;
                            nbi_store.Enabled = true;
                            nbi_setinventory.Enabled = true;
                            nbi_returntounit.Enabled = true;
                            break;
                        }
                    case (8)://Кадровая подборка
                        {
                            bbi_pass.Enabled = false;
                            bbi_send.Enabled = false;
                            bbi_return.Enabled = false;
                            bbi_in_act.Enabled = false;
                            bbi_hemming.Enabled = false;
                            bbi_remove_from_act.Enabled = false;
                            bbi_re_register.Enabled = false;
                            bbi_store.Enabled = false;
                            bbi_setInventory.Enabled = false;
                            bbi_returnToUnit.Enabled = false;

                            nbi_pass.Enabled = false;
                            nbi_send.Enabled = false;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = false;
                            nbi_hemming.Enabled = false;
                            nbi_reregister.Enabled = false;
                            nbi_store.Enabled = false;
                            nbi_setinventory.Enabled = false;
                            nbi_returntounit.Enabled = false;
                            break;
                        }
                    case (9)://Передан на хранение
                        {
                            bbi_pass.Enabled = false;
                            bbi_send.Enabled = false;
                            bbi_return.Enabled = false;
                            bbi_in_act.Enabled = false;
                            bbi_hemming.Enabled = false;
                            bbi_remove_from_act.Enabled = false;
                            bbi_re_register.Enabled = false;
                            bbi_store.Enabled = false;
                            bbi_setInventory.Enabled = false;
                            bbi_returnToUnit.Enabled = false;

                            nbi_pass.Enabled = false;
                            nbi_send.Enabled = false;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = false;
                            nbi_hemming.Enabled = false;
                            nbi_reregister.Enabled = false;
                            nbi_store.Enabled = false;
                            nbi_setinventory.Enabled = false;
                            nbi_returntounit.Enabled = false;
                            break;
                        }
                    case (10)://Перерегитрирован на номер
                        {
                            bbi_pass.Enabled = false;
                            bbi_send.Enabled = false;
                            bbi_return.Enabled = false;
                            bbi_in_act.Enabled = false;
                            bbi_hemming.Enabled = false;
                            bbi_remove_from_act.Enabled = false;
                            bbi_re_register.Enabled = false;
                            bbi_store.Enabled = false;
                            bbi_setInventory.Enabled = false;
                            bbi_returnToUnit.Enabled = false;

                            nbi_pass.Enabled = false;
                            nbi_send.Enabled = false;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = false;
                            nbi_hemming.Enabled = false;
                            nbi_reregister.Enabled = false;
                            nbi_store.Enabled = false;
                            nbi_setinventory.Enabled = false;
                            nbi_returntounit.Enabled = false;
                            break;
                        }
                    case (11)://Вошел в инвентарь
                        {
                            bbi_pass.Enabled = false;
                            bbi_send.Enabled = false;
                            bbi_return.Enabled = false;
                            bbi_in_act.Enabled = false;
                            bbi_hemming.Enabled = false;
                            bbi_remove_from_act.Enabled = false;
                            bbi_re_register.Enabled = false;
                            bbi_store.Enabled = false;
                            bbi_returnToUnit.Enabled = false;
                            bbi_setInventory.Enabled = false;

                            nbi_pass.Enabled = false;
                            nbi_send.Enabled = false;
                            nbi_return.Enabled = false;
                            nbi_inact.Enabled = false;
                            nbi_hemming.Enabled = false;
                            nbi_reregister.Enabled = false;
                            nbi_store.Enabled = false;
                            nbi_setinventory.Enabled = false;
                            nbi_returntounit.Enabled = false;
                            break;
                        }
                    default:
                        {
                            bbi_pass.Enabled = true;
                            bbi_send.Enabled = true;
                            bbi_return.Enabled = true;
                            bbi_in_act.Enabled = true;
                            bbi_hemming.Enabled = true;
                            bbi_remove_from_act.Enabled = true;
                            bbi_re_register.Enabled = true;
                            bbi_store.Enabled = true;
                            bbi_setInventory.Enabled = true;
                            bbi_returnToUnit.Enabled = true;

                            nbi_pass.Enabled = true;
                            nbi_send.Enabled = true;
                            nbi_return.Enabled = true;
                            nbi_inact.Enabled = true;
                            nbi_hemming.Enabled = true;
                            nbi_reregister.Enabled = true;
                            nbi_store.Enabled = true;
                            nbi_setinventory.Enabled = true;
                            nbi_returntounit.Enabled = true;
                            break;
                        }
                }

                bbi_pass.Enabled = TheAbilityToEditTheDoc && bbi_pass.Enabled;
                bbi_send.Enabled = TheAbilityToEditTheDoc && bbi_send.Enabled;
                bbi_return.Enabled = TheAbilityToEditTheDoc && bbi_return.Enabled;
                bbi_in_act.Enabled = TheAbilityToEditTheDoc && bbi_in_act.Enabled;
                bbi_hemming.Enabled = TheAbilityToEditTheDoc && bbi_hemming.Enabled;
                bbi_remove_from_act.Enabled = TheAbilityToEditTheDoc && bbi_remove_from_act.Enabled;
                bbi_re_register.Enabled = TheAbilityToEditTheDoc && bbi_re_register.Enabled;
                bbi_store.Enabled = TheAbilityToEditTheDoc && bbi_store.Enabled;
                bbi_newEkz.Enabled = TheAbilityToEditTheDoc && bbi_newEkz.Enabled;
                bbi_setInventory.Enabled = TheAbilityToEditTheDoc && bbi_setInventory.Enabled;
                bbi_returnToUnit.Enabled = TheAbilityToEditTheDoc && bbi_returnToUnit.Enabled;
                bbi_remove_from_act.Enabled = GlobalClass.TheModeOfFormationOfTheAct;
            }
        }
        private void SaveView(Документы doc, IList<StringsF4> stringF4S)
        {
            if (doc.ВидИКраткоеСодержаниеs.Count() <= stringF4S.Count())
            {
                int i;
                for (i = 0; i <= (doc.ВидИКраткоеСодержаниеs.Count() - 1); i++)
                {

                    var dbStr = doc.ВидИКраткоеСодержаниеs[i];
                    var memStr = stringF4S[i];
                    dbStr.НомерСтроки = i;
                    dbStr.ПризнакПечати = (bool)memStr.ПризнакПечати;
                    dbStr.Текст = !string.IsNullOrEmpty(memStr.Текст) ? memStr.Текст : "";
                    if (i == 0)
                    {
                        doc.НазваниеДокумента = memStr.Текст;
                    }
                }

                while (i < stringF4S.Count())
                {
                    var dbStr = new ВидИКраткоеСодержание();
                    var memStr = stringF4S[i];
                    dbStr.НомерСтроки = i;
                    dbStr.ПризнакПечати = (bool)memStr.ПризнакПечати;
                    dbStr.Текст = !string.IsNullOrEmpty(memStr.Текст) ? memStr.Текст : "";
                    if (i == 0)
                    {
                        doc.НазваниеДокумента = memStr.Текст;
                    }
                    doc.ВидИКраткоеСодержаниеs.Add(dbStr);
                    i++;
                }
            }
            else
            {
                int i;
                for (i = 0; i < (doc.ВидИКраткоеСодержаниеs.Count() - 1); i++)
                {
                    ВидИКраткоеСодержание dbStr = doc.ВидИКраткоеСодержаниеs[i];
                    StringsF4 memStr = stringF4S[i];
                    dbStr.НомерСтроки = i;
                    dbStr.ПризнакПечати = (bool)memStr.ПризнакПечати;
                    dbStr.Текст = !string.IsNullOrEmpty(memStr.Текст) ? memStr.Текст : "";
                    if (i == 0)
                    {
                        doc.НазваниеДокумента = memStr.Текст;
                    }
                }
                while (i < doc.ВидИКраткоеСодержаниеs.Count())
                {
                    doc.ВидИКраткоеСодержаниеs.RemoveAt(i);
                    i++;
                }

            }
            GlobalClass.Dc.SubmitChanges();
        }
        private void SaveResolutions(Документы doc, IList<StringsF4> stringF4S)
        {
            if (doc.Резолюцияs.Count() <= stringF4S.Count())
            {
                int i;
                for (i = 0; i <= (doc.Резолюцияs.Count() - 1); i++)
                {

                    Резолюция dbStr = doc.Резолюцияs[i];
                    StringsF4 memStr = stringF4S[i];
                    dbStr.НомерСтроки = memStr.НомерСтроки;
                    //dbStr.ПризнакПечати = memStr.ПризнакПечати;
                    if (memStr.Текст != "")
                    {
                        dbStr.Текст = memStr.Текст;
                    }
                }

                while (i < stringF4S.Count())
                {
                    var dbStr = new Резолюция();
                    StringsF4 memStr = stringF4S[i];
                    dbStr.НомерСтроки = memStr.НомерСтроки;
                    //dbStr.ПризнакПечати = memStr.ПризнакПечати;
                    dbStr.Текст = memStr.Текст;
                    doc.Резолюцияs.Add(dbStr);
                    i++;
                }
            }
            else
            {
                int i;
                for (i = 0; i < (doc.Резолюцияs.Count() - 1); i++)
                {
                    Резолюция dbStr = doc.Резолюцияs[i];
                    StringsF4 memStr = stringF4S[i];
                    dbStr.НомерСтроки = memStr.НомерСтроки;
                    dbStr.ПризнакПечати = memStr.ПризнакПечати;
                    dbStr.Текст = memStr.Текст;
                }
                while (i < doc.Резолюцияs.Count())
                {
                    doc.Резолюцияs.RemoveAt(doc.Резолюцияs.Count - 1);
                    i++;
                }

            }
            GlobalClass.Dc.SubmitChanges();
        }
        private void ChangeHostMethod()
        {
            AvailabilityOperations();
            _formF4.LoadResolution(_документ);
            _formF4.LoadCase(_документ);
            _formF4.LoadAct(_документ);

        }
        private void ChangeCaseMethod()
        {
            AvailabilityOperations();
            _formF4.LoadCase(_документ);
        }
        private void ReturnDocument()
        {
            if (_документ.ЖурналОперацийs.OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).Select(p => p.id_операции).FirstOrDefault() == 4)
            {
                MessageBox.Show(@"Документ находится в акте! Вернуть документ можно через удалние из акта.", @"Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_документ.ЖурналОперацийs.OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).Select(p => p.id_операции).FirstOrDefault() != 3 && _документ.ЖурналОперацийs.OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).Select(p => p.id_операции).FirstOrDefault() != 5)
            {
                Methods.CloseDistiny(_документ,DateTime.Today);
                _документ.Наличие = true;
                _документ.Закрыт = false;
                var sb = new StringBuilder();
                sb.Append(DateTime.Today.ToShortDateString());
                sb.Append(" Документ возвращен");
                Methods.AddNewDistiny(_документ, 0, Operations.Return, sb.ToString(), DateTime.Today);
                GlobalClass.Dc.SubmitChanges();
                MessageBox.Show(@"Документ возвращен", @"Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DestroyDocument()
        {
            Methods.CloseDistiny(_документ,DateTime.Today);
            _документ.НаУдаление = false;
            _документ.Наличие = true;
            _документ.Закрыт = false;
            var bindOperation = Methods.AddNewDistiny(_документ, 0, Operations.AddToAct, DateTime.Today.ToShortDateString() + " Документ уничтожен.", DateTime.Today);
            Methods.AddNewResolution(_документ,DateTime.Today.ToShortDateString() + " Документ уничтожен.",bindOperation);
            GlobalClass.Dc.SubmitChanges();
            MessageBox.Show(@"Документ уничтожен.", @"Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChangeHostMethod();
         }
        private void AddToQueueDestruction()
        {
            Methods.CloseDistiny(_документ,DateTime.Today);
            _документ.НаУдаление = !_документ.НаУдаление;
            _документ.Наличие = true;
            
            if (_документ.НаУдаление)
            {
                var bindOperation = Methods.AddNewDistiny(_документ, 0, Operations.IntoTheQueue, DateTime.Today.ToShortDateString() + " Документ добавлен в очередь на уничтожение", DateTime.Today);
                Methods.AddNewResolution(_документ, DateTime.Today.ToShortDateString() + " В акт на уничтожение", bindOperation);
                _документ.Закрыт = true;
            }
            else
            {
                Methods.AddNewDistiny(_документ, 0, Operations.FromQueue, DateTime.Today.ToShortDateString() + " Документ удален из очереди на уничтожение", DateTime.Today);
                Methods.DeleteTheLastResolution(_документ);
                _документ.Закрыт = false;

            }
            GlobalClass.Dc.SubmitChanges();
            MessageBox.Show(_документ.НаУдаление ? @"Документ добавлен в очередь на удаление." : @"Документ удален из очереди на удаление.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }
        private void ReRegistration(Документы newDoc)
        {
            var sb = new StringBuilder();
            sb.Append(DateTime.Today.ToShortDateString());
            sb.Append(" перерегистрирован на № ");
            sb.Append(newDoc.ПолныйВходящийНомер);
            sb.Append(" за ");
            sb.Append(newDoc.ДатаРегистрации.Value.Year);
            sb.Append(" год");
            Methods.CloseDistiny(_документ, DateTime.Today);
            var bindOperetion = Methods.AddNewDistiny(_документ, 0, Operations.Reregistration, sb.ToString(), DateTime.Today);
            Methods.AddNewView(newDoc,"Перерегистрирован с № "+_документ.ПолныйВходящийНомер+" за "+_документ.ДатаРегистрации.Value.Year+" год");
            Methods.AddNewResolution(_документ, sb.ToString(),bindOperetion);
            _документ.Закрыт = true;
            _документ.Перерегистрирован = newDoc.id_документа; 
            GlobalClass.Dc.SubmitChanges();

        }

        private void ToMAkeTheDataAct()
        {
            var setAct = new SetAct(_документ);
            setAct.MakeDataAct();
            Methods.CloseDistiny(_документ, DateTime.Today);
            var bindOperation =  Methods.AddNewDistiny(_документ, 0, Operations.AddToAct, DateTime.Today.ToShortDateString() + " Добавлен в акт на уничтожение", DateTime.Today);
            Methods.AddNewResolution(_документ, DateTime.Today.ToShortDateString() + " В акт на уничтожение",bindOperation);
            GlobalClass.Dc.SubmitChanges();
        }

        

        private void ResetTheNumberOfPrints(Документы doc)
        {
            doc.ПризнакПечати = false;
            foreach (var str in doc.ВидИКраткоеСодержаниеs)
            {
                str.ПризнакПечати = false;
            }
            foreach (var str in doc.Резолюцияs)
            {
                str.ПризнакПечати = false;
            }
            _документ.ПризнакПечати = false;
            _документ.НомерПродолжения = 0;
            SaveDocument();
            InitOfAuthority();//определить видимость сброса параметров печати

        }
        private void InStore()
        {
            var frm = new TextForm("Передан на хранение");
            var comment = frm.OpenDialog();
            var sb = new StringBuilder();
            sb.Append(DateTime.Today.ToShortDateString());
            sb.Append(" передан на хранение ");
            sb.Append(comment);

            Methods.CloseDistiny(_документ, DateTime.Today);

            var bindOperation = Methods.AddNewDistiny(_документ, 0, Operations.IntoStorage, sb.ToString(), DateTime.Today);
            Methods.AddNewResolution(_документ,sb.ToString(),bindOperation);
            _документ.Закрыт = true;
            GlobalClass.Dc.SubmitChanges();
        }

        private void UndoLastOperation()
        {
            var журналОпераций = GlobalClass.Dc.ЖурналОперацийs.Where(p => p.id_документа == _документ.id_документа).OrderByDescending(p => p.датаНачалаОперации).ThenByDescending(p => p.id_записи).FirstOrDefault();
            if (журналОпераций != null)
            {
                
                switch ((Operations)журналОпераций.id_операции)
                {
                    case (Operations.Transfer): { _formF4.DeleteLastResolution(_документ,журналОпераций.id_записи); Methods.DeleteLastDistiny(_документ); break; } //передан
                    case (Operations.Send): { _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи); Methods.DeleteLastDistiny(_документ); break; } //отправлен
                    case (Operations.Return): { Methods.DeleteLastDistiny(_документ);break; } // возвращен
                    case (Operations.IntoTheQueue): { Methods.DeleteLastDistiny(_документ); _документ.НаУдаление = !_документ.НаУдаление; break; } // добален в очередь
                    case (Operations.AddToAct):
                    {
                        if (IsNonSecret())
                        {
                            _документ.Код_акта = 0;
                            _formF4.ClearAct(_документ);
                            _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи);
                            Methods.DeleteLastDistiny(_документ);
                        }
                        else
                        {
                            if (GlobalClass.TheModeOfFormationOfTheAct)
                            {
                                if (WasPerformed()) { MessageBox.Show(@"Внимание", @"Данный документ находится в исполненном акте. Удалить его из акта невозможно.", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                else
                                {
                                    if (MessageBox.Show(@"Вы хотите удалить документ из акта. Вы уверены?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        _документ.Код_акта = 0;
                                        _formF4.ClearAct(_документ);
                                        _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи); 
                                        Methods.DeleteLastDistiny(_документ);
                                    }
                                }
                            }
                            else
                            {
                                _документ.Код_акта = 0;
                                _formF4.ClearAct(_документ);
                                _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи);
                                Methods.DeleteLastDistiny(_документ);
                            }
                        }
                        //ChangeHostMethod();
                        
                        break;
                    } // добавлен в акт
                    case (Operations.InCase): { _formF4.ClearCase(_документ); Methods.DeleteLastDistiny(_документ); break; } // подшит в дело
                    case (Operations.FromQueue): { _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи); Methods.DeleteLastDistiny(_документ); _документ.НаУдаление = !_документ.НаУдаление; break; } // удален из очереди
                    case (Operations.PersonnelSelection): { _formF4.ClearMaterial(_документ); Methods.DeleteLastDistiny(_документ); break; } // кадровая подборка
                    case (Operations.IntoStorage): { _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи); Methods.DeleteLastDistiny(_документ); break; } // передан на хранение
                    case (Operations.Reregistration): { 
                        _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи); 
                        Methods.DeleteLastDistiny(_документ);
                        var newDoc = GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == _документ.Перерегистрирован);
                        Methods.DeleteTheLastView(newDoc); 
                        if (XtraMessageBox.Show("Удалить документ на который была произведена перерегистрация?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Methods.DeleteDocument(GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа==_документ.Перерегистрирован));
                        }
                        _документ.Перерегистрирован = null;
                        SaveDocument();
                       
                        break; } // перерегистрирован
                    case (Operations.ToInventory): { _formF4.DeleteLastResolution(_документ, журналОпераций.id_записи); Methods.DeleteLastDistiny(_документ); break; }
                }
            }
        }

        public bool IsNonSecret() { return _документ.id_грифа == 1; }
        public bool WasPerformed() { return GlobalClass.Dc.АктыНаУничтожениеs.Where(p=>p.Код_акта==_документ.Код_акта).Select(p=>p.АктИсполнен).FirstOrDefault(); }

        private void inCaseForm_changeCase()
        {
            SaveDocument();
            ChangeCaseMethod();
        }

        private void bbi_send_ItemClick(object sender, ItemClickEventArgs e) { SendMethod();}

        private void SendMethod()
        {
            SaveDocument();
            var passForm = new PassForm(_документ, TransmissionsType.Send);
            passForm.Show();
            passForm.changeHost += passForm_changeHost;
        }

        private void bbi_return_ItemClick(object sender, ItemClickEventArgs e) { ReturnMethod();}

        private void ReturnMethod()
        {
            SaveDocument();
            ReturnDocument();
            ChangeHostMethod();
        }

        private void bbi_in_act_ItemClick(object sender, ItemClickEventArgs e) {
            InActMethod();
        }

        private void InActMethod()
        {
            SaveDocument();
            if (IsNonSecret()) { DestroyDocument(); }
            else
            {
                if (GlobalClass.TheModeOfFormationOfTheAct) { AddToQueueDestruction(); }
                else
                { ToMAkeTheDataAct(); }
            }
            ChangeHostMethod();
        }

        private void bbi_pass_ItemClick(object sender, ItemClickEventArgs e) { PassMethod();}

        private void PassMethod()
        {
            SaveDocument();
            var passForm = new PassForm(_документ, TransmissionsType.Transfer);
            passForm.Show();
            passForm.changeHost += passForm_changeHost;
        }

        private void bbi_remove_from_act_ItemClick(object sender, ItemClickEventArgs e) { FormActMethod();}

        private void FormActMethod()
        {
            SaveDocument();
            if (GlobalClass.TheModeOfFormationOfTheAct) { AddToQueueDestruction(); }
            else
            { }
            ChangeHostMethod();
        }

        private void bbi_hemming_ItemClick(object sender, ItemClickEventArgs e) { InCaseMethod();}

        private void InCaseMethod()
        {
            SaveDocument();
            var inCaseForm = new InCaseForm(_документ);
            _документ = inCaseForm.MakeDataCase();
            ChangeHostMethod();
        }

        private void bbi_cancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveDocument();
            UndoLastOperation();
            AvailabilityOperations();
        }
        private void bbi_re_register_ItemClick(object sender, ItemClickEventArgs e) { ReRegistrMethod();}

        private void ReRegistrMethod()
        {
            SaveDocument();
            var fReRegistr = new ReRegistr();
            var reType = fReRegistr.OpenDialog();
            if (reType == ReType.NewDocument)
            {
                var newDoc = _документ.Copy();
                newDoc = Methods.InitIncommingNumber(newDoc);
                newDoc.ДатаРегистрации = DateTime.Today;
                GlobalClass.Dc.Документыs.InsertOnSubmit(newDoc);
                GlobalClass.Dc.SubmitChanges();
                SaveView(newDoc, _formF4.StringsViewF4S);
                ReRegistration(newDoc);
                _документ = newDoc;
                _formF4 = new FormF4(newDoc, (newDoc.ПризнакПечати.HasValue && (bool) newDoc.ПризнакПечати));
                Methods.SetInPanelFormF4(panelForm, _formF4);
                SaveView(newDoc, _formF4.StringsViewF4S);
            }
            if (reType == ReType.ExistingDocument)
            {
                if (_документ.ДатаРегистрации != null)
                {
                    var form = new ReRegistration(DateTime.Today.Year);
                    var newDoc = form.OpenDialog();
                    if (newDoc != null) ReRegistration(newDoc);
                }
            }
            ChangeHostMethod();
        }

        private void barFateOfTheDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var destiny = new Destiny(_документ);
            var freeForm = new FreeForm("Судьба документа",destiny);
            freeForm.Show();
        }

        private void bbi_store_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveDocument();
            InStore();
            ChangeHostMethod();
        }

        private void barPrintCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveDocument();
            PrintCard();
            if(GlobalClass.ClosesTheWindowAfterPrinting){this.Close();}

        }

        private void PrintCard()
        {
            var l = new List<KeyValuePair<string, string>> {new KeyValuePair<string, string>("user", "")};
            Methods.ПечатьФ4СНастройкамиУк(_документ, l);
            _документ.ПризнакПечати = true;
            SaveDocument();
            InitOfAuthority();//определить видимость сброса параметров печати
        }

        private void SaveDocument()
        {
            if (_formF4.КомуПоступил == null) return;
            var doc = _документ != default(Документы) ? _документ : new Документы();
            doc.ДатаРегистрации = _formF4.ДатаРегистрации;
            doc.Грифы = _formF4.Гриф;
            if (string.IsNullOrEmpty(_formF4.ВходящийНомер))
            {
                if (doc.ВходящийНомер == null) { doc = Methods.InitIncommingNumber(doc); }
            }
            else
            { doc.ПолныйВходящийНомер = _formF4.ВходящийНомер; }
            if (_formF4.ДатаКонтроля != default(DateTime)) { doc.ДатаКонтроля = _formF4.ДатаКонтроля; }
            if (_formF4.ДатаПодписи != default(DateTime)) { doc.ДатаПодписи = _formF4.ДатаПодписи; }
                
            doc.НомерЭкземпляра = _formF4.НомерЭкземпляра;
            doc.КоличествоЛистовЭкзепляра = _formF4.КоличестовЛистов;
            doc.КоличествоЛистовПриложения = _formF4.КоличествоПриложений;
            doc.НомераПриложений = _formF4.НомераПриложений;
            doc.РегНомер = _formF4.РегНомер;
            doc.Подразделения = _formF4.ОткудаПоступил;
            doc.КомуАдресован = _formF4.КомуПоступил;
            doc.ИсполнениеНомер = _formF4.Исполнение;
            doc.ДелоНомер = _formF4.Дело;
            doc.Том = _formF4.ТомНомер;
            doc.Лист = _formF4.Лист;
            doc.от = _formF4.От;
            doc.Вернуть = _formF4.ТребуетсяВернуть;
            doc.ДатаВозврата = _formF4.ДатаВозврата != default(DateTime) ? _formF4.ДатаВозврата : null;
            doc.ДопМатериалы = _formF4.Материалы;
            doc.id_пользователя = GlobalClass.CurrentUser.id_пользователя;
            doc.id_журанала = GlobalClass.Dc.Журналыs.Select(p => p.id_журнала).FirstOrDefault();
            doc.ВидДокумента = _formF4.ВидПоступившегоДокумента;
            doc.Акт = _formF4.Акт;
            doc.от2 = _formF4.ДатаАкта;
            doc.КомментарийКому = _formF4.КомментарийКуда;
            doc.КомментарийОткуда = _formF4.КомментарийОткуда;
            try
            {
                GlobalClass.Dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Обратитесь к программисту разработчику. Сообщите информацию об ошибке : " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SaveView(doc, _formF4.StringsViewF4S);
            SaveResolutions(doc, _formF4.StringsResolutionF4S);
            if (UpdateBsForJournal != null) { UpdateBsForJournal(); }
        }

        private void barClearParams_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResetTheNumberOfPrints(_документ);
        }

        private void bbi_newEkz_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveDocument();
            var newEkz = _документ.Copy();
            int ekz;

            if (!string.IsNullOrEmpty(newEkz.НомерЭкземпляра))
            {
                do
                {
                    var frm = new CalcForm(@"Номер экземпляра");
                    ekz = frm.OpenDialog();
                }
                while (ekz== 0 || ekz== int.Parse(newEkz.НомерЭкземпляра));

            }
            else
            {
                do
                {
                    var frm = new CalcForm(@"Номер экземпляра");
                    ekz = frm.OpenDialog();
                }
                while (ekz == 0);
            }
           


            var unitFrm = new SelectForce();
            newEkz.id_получателя=unitFrm.OpenDialog(@"Выберите кому адресован экземпляр", _документ.КомуАдресован).id_получателя;


            newEkz.НомерЭкземпляра = ekz.ToString(CultureInfo.InvariantCulture);
            GlobalClass.Dc.Документыs.InsertOnSubmit(newEkz);
            GlobalClass.Dc.SubmitChanges();
            SaveView(newEkz, _formF4.StringsViewF4S);

            _документ = newEkz; 
            SaveDocument();
            _formF4 = new FormF4(newEkz, (newEkz.ПризнакПечати.HasValue && (bool)newEkz.ПризнакПечати));
            Methods.SetInPanelFormF4(panelForm, _formF4);


        }

        private void bbi_returnToUnit_ItemClick(object sender, ItemClickEventArgs e) {ReturnToUnitMethod();}

        private void ReturnToUnitMethod()
        {
            if (_документ.id_подразделения == null) return;
            Methods.SendInUnit(_документ, _документ.id_подразделения.Value, "", DateTime.Now);
            _документ.Вернуть = false;
            _документ.Закрыт = true;
            ChangeHostMethod();
        }

        private void InitOfAuthority()
        {
            #region Операции

            barAction.Visibility = GlobalClass.CanEdit?BarItemVisibility.Always : BarItemVisibility.Never;
            bbi_newEkz.Visibility = GlobalClass.CanEdit ? BarItemVisibility.Always : BarItemVisibility.Never;
            nbc_SideMenu.OptionsNavPane.NavPaneState = GlobalClass.UseTheSideMenu ? NavPaneState.Expanded : NavPaneState.Collapsed;
            
            

            #endregion

            #region Печать

            barPrintCard.Visibility = GlobalClass.PrintCard ? BarItemVisibility.Always : BarItemVisibility.Never;
            barClearParams.Visibility = GlobalClass.PrintCard && Print==PrintMode.Partially ? BarItemVisibility.Always : BarItemVisibility.Never;
            bsi_PrintFunction.Visibility = GlobalClass.PrintCard ? BarItemVisibility.Always : BarItemVisibility.Never;
            bbi_PrintContinue.Visibility = GlobalClass.PrintingReverseSide ? BarItemVisibility.Never : BarItemVisibility.Always;
            bbi_printingPerfomance.Visibility = GlobalClass.PrintingReverseSide ? BarItemVisibility.Always : BarItemVisibility.Never;

            #endregion

            #region Перерегистрация

            bsi_GoToNewDoc.Visibility = _документ.Перерегистрирован.HasValue? BarItemVisibility.Always : BarItemVisibility.Never;

            #endregion

        }

        private void bbi_setInventory_ItemClick(object sender, ItemClickEventArgs e) {SetInventoryMethod();}

        private void SetInventoryMethod()
        {
            SaveDocument();
            var setInventory = new SetInventory();
            setInventory.Show();
            GlobalClass.Dc.SubmitChanges();
            ChangeHostMethod();
        }

        private void bbi_PrintContinie_ItemClick(object sender, ItemClickEventArgs e)
        {
            var l = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("user", "") };
            var calcForm = new CalcForm("Номер продолжения");
            ResetTheNumberOfPrints(_документ);
            _документ.НомерПродолжения = calcForm.OpenDialog();
            Methods.ПечатьФ4СНастройкамиУк(_документ, l);
        }

        private void AddDocForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            if (GlobalClass.CanEdit) { SaveDocument(); }
            Close();
        }

        private void bsi_GoToNewDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var документ = GlobalClass.Dc.Документыs.FirstOrDefault(p => p.id_документа == _документ.Перерегистрирован);
            if (_документ == null) return;
            _документ = документ;
            InitForm();
        }

        private void nbi_pass_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PassMethod();
        }

        private void nbi_send_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SendMethod();
        }

        private void nbi_return_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ReturnMethod();
        }

        private void nbi_inact_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            InActMethod();
        }

        private void nbi_hemming_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            InCaseMethod();
        }

        private void nbi_cancel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveDocument();
            UndoLastOperation();
            AvailabilityOperations();
        }

        private void nbi_reregister_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ReRegistrMethod();
        }

        private void nbi_store_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveDocument();
            InStore();
            ChangeHostMethod();
        }

        private void nbi_returntounit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ReturnToUnitMethod();
        }

        private void nbi_setinventory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SetInventoryMethod();
        }

        private void nbc_SideMenu_NavPaneStateChanged(object sender, EventArgs e)
        {
            
        }

        

      
    }

    
}