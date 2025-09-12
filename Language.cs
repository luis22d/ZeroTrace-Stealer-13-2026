using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ZeroTrace_Stealer
{
	public partial class language: DevExpress.XtraEditors.XtraForm
	{
        public string SelectedLanguage { get; private set; }
        public language()
		{
            InitializeComponent();
            SelectedLanguage = "English";
        }

        private void language_Load(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Properties.Items.Count == 0)
            {
                comboBoxEdit1.Properties.Items.AddRange(new string[]
                {
                    "English",
                    "Spain",
                    "Italian",
                    "France",
                    "Chinese",
                    "Deutsche"
                });
            }

            // Set default selection to English
            comboBoxEdit1.SelectedIndex = 0;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            LanguageSelector.SelectedLanguage = comboBoxEdit1.Text;

            // Hide the language selection form
            this.Hide();

            // Show the main form (no constructor parameter needed)
            Form1 mainForm = new Form1();
            mainForm.Show();

            // Close the language form when the main form closes
            mainForm.FormClosed += (s, args) => this.Close();
        }
    }
}

namespace ZeroTrace_Stealer
{
    public static class TranslationManager
    {
        // Dictionary to store translations for all languages
        private static Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

        // Initialize translations for all supported languages
        static TranslationManager()
        {
            // English (default, no need to translate)
            translations["English"] = new Dictionary<string, string>();

            // Spanish translations
            translations["Spain"] = new Dictionary<string, string>
            {
                { "label1", "Registro total" },
                { "label3", "Durante todo este tiempo" },
                { "label6", "Última semana" },
                { "label4", "Durante toda la semana" },
                { "label9", "Últimos 30 días" },
                { "label7", "Durante todo el mes" },
                { "label12", "Contraseñas totales" },
                { "label10", "Durante todo el tiempo" },
                { "label85", "Constructor" },
                { "label88", "Todas las funciones están activadas automáticamente." },
                { "label39", "Escuchar en el puerto elegido" },
                { "label37", "Estado" },
                { "simpleButton13", "Construir" },
                { "simpleButton2", "Guardar todos los registros en disco" },
                { "simpleButton3", "Verificador de registros" },
                { "simpleButton4", "Buscar *Metamask en disco" },
                { "simpleButton5", "Buscar *Todas las carteras en disco" },
                { "simpleButton6", "Borrar todos los registros" },
                { "simpleButton7", "Eliminar todos los registros" },
                { "simpleButton1", "Iniciar el servidor ZeroTrace en el puerto elegido" },
                { "simpleButton12", "Buscar *Billetera Metamask" },
                { "simpleButton11", "Buscar *Billetera Exodus" },
                { "simpleButton10", "Borrar lista de contraseñas" },
                { "simpleButton9", "Buscar *Sitio web específico" },
                { "simpleButton8", "Buscar *Contraseñas en disco" },
                { "accordionControlElement1", "Panel de control" },
                { "accordionControlElement2", "Registros" },
                { "accordionControlElement3", "Configuración del Stealer" },
                { "accordionControlElement4", "Acerca de" },
                { "accordionControlElement5", "Constructor" },
                { "accordionControlElement6", "Construir ZeroTrace" },
                { "accordionControlElement7", "Acerca de" },
                { "accordionControlElement8", "Salir del software" },
                { "accordionControlElement9", "Salir" },
                { "label86", "Acerca de ZeroTrace Stealer" },
                { "label86_longText", "ZeroTrace Stealer es una herramienta avanzada de recopilación de datos creada por el equipo ZeroTrace, diseñada para ayudar en la recopilación integral de datos. Desarrollada con tecnologías de vanguardia, proporciona a los usuarios la capacidad de recopilar y gestionar información sensible de manera eficiente.\nCaracterísticas principales:\nExtracción de contraseñas: Recopila contraseñas almacenadas de navegadores, aplicaciones y más.\nCookies y registros de sesión: Recopila cookies y detalles de sesión para un acceso rápido.\nRecolección de archivos: Se dirige a tipos de archivos específicos de directorios predefinidos.\nDatos de Discord/Telegram: Captura tokens y credenciales para plataformas de comunicación.\nCapturas de pantalla y detalles del sistema: Captura automáticamente capturas de pantalla del escritorio y extrae información del sistema.\nDatos de juegos y configuraciones VPN: Recupera perfiles de juegos y detalles de VPN.\nIntegración del panel: Envía datos recopilados de forma segura a su panel personalizado para su análisis.\nY mucho más.\nDiseñado para uso profesional\nZeroTrace Stealer está diseñado para profesionales de pruebas de penetración y hacking ético.\nLa herramienta demuestra la importancia de proteger la información sensible y sirve como recordatorio para mejorar las medidas de ciberseguridad.\nDescargo de responsabilidad: ZeroTrace Stealer está destinado únicamente a fines educativos.\nLos desarrolladores prohíben estrictamente su uso para actividades ilegales o no éticas." },
                { "label90", "El software original solo se puede encontrar en nuestra página de Github." },
                { "label75", "Este software es completamente gratuito. Si lo compró, cometió un error." }
            };

            // Italian translations
            translations["Italian"] = new Dictionary<string, string>
            {
                { "label1", "Log totale" },
                { "label3", "Durante tutto questo tempo" },
                { "label6", "Ultima settimana" },
                { "label4", "Durante tutta la settimana" },
                { "label9", "Ultimi 30 giorni" },
                { "label7", "Durante tutto il mese" },
                { "label12", "Password totali" },
                { "label10", "Durante tutto il tempo" },
                { "label85", "Builder" },
                { "label88", "Tutte le funzionalità sono attivate automaticamente." },
                { "label39", "Ascolta sulla porta scelta" },
                { "label37", "Stato" },
                { "simpleButton13", "Costruisci" },
                { "simpleButton2", "Salva tutti i log su disco" },
                { "simpleButton3", "Controllore dei log" },
                { "simpleButton4", "Cerca *Metamask su disco" },
                { "simpleButton5", "Cerca *Tutti i portafogli su disco" },
                { "simpleButton6", "Cancella tutti i log" },
                { "simpleButton7", "Elimina tutti i log" },
                { "simpleButton1", "Avvia il server ZeroTrace sulla porta scelta" },
                { "simpleButton12", "Cerca *Portafoglio Metamask" },
                { "simpleButton11", "Cerca *Portafoglio Exodus" },
                { "simpleButton10", "Cancella lista password" },
                { "simpleButton9", "Cerca *Sito web specifico" },
                { "simpleButton8", "Cerca *Password su disco" },
                { "accordionControlElement1", "Dashboard" },
                { "accordionControlElement2", "Log" },
                { "accordionControlElement3", "Impostazioni Stealer" },
                { "accordionControlElement4", "Informazioni" },
                { "accordionControlElement5", "Builder" },
                { "accordionControlElement6", "Costruisci ZeroTrace" },
                { "accordionControlElement7", "Informazioni" },
                { "accordionControlElement8", "Esci dal software" },
                { "accordionControlElement9", "Esci" },
                { "label86", "Informazioni su ZeroTrace Stealer" },
                { "label86_longText", "ZeroTrace Stealer è uno strumento avanzato di raccolta dati creato dal team ZeroTrace, progettato per assistere nella raccolta completa di dati. Sviluppato con tecnologie all'avanguardia, fornisce agli utenti la capacità di raccogliere e gestire informazioni sensibili in modo efficiente.\nFunzionalità principali:\nEstrazione password: Raccoglie password memorizzate da browser, app e altro.\nCookie e log di sessione: Raccoglie cookie e dettagli della sessione per un accesso rapido.\nRaccolta file: Mira a tipi di file specifici da directory predefinite.\nDati Discord/Telegram: Cattura token e credenziali per piattaforme di comunicazione.\nScreenshot e dettagli del sistema: Cattura automaticamente screenshot del desktop ed estrae informazioni di sistema.\nDati di gioco e configurazioni VPN: Recupera profili di gioco e dettagli VPN.\nIntegrazione del pannello: Invia i dati raccolti in modo sicuro al tuo pannello personalizzato per l'analisi.\nE molto altro ancora.\nProgettato per uso professionale\nZeroTrace Stealer è progettato per professionisti di penetration testing ed ethical hacking.\nLo strumento dimostra l'importanza di proteggere le informazioni sensibili e serve come promemoria per migliorare le misure di cybersecurity.\nDisclamer: ZeroTrace Stealer è destinato solo a scopi educativi.\nGli sviluppatori ne vietano rigorosamente l'uso per attività illegali o non etiche." },
                { "label90", "Il software originale si trova solo sulla nostra pagina Github." },
                { "label75", "Questo software è completamente gratuito. Se l'hai acquistato, hai commesso un errore." }
            };

            // French translations
            translations["France"] = new Dictionary<string, string>
            {
                { "label1", "Journal total" },
                { "label3", "Pendant tout ce temps" },
                { "label6", "Semaine dernière" },
                { "label4", "Pendant toute la semaine" },
                { "label9", "30 derniers jours" },
                { "label7", "Pendant tout le mois" },
                { "label12", "Mots de passe totaux" },
                { "label10", "Pendant tout le temps" },
                { "label85", "Constructeur" },
                { "label88", "Toutes les fonctionnalités sont automatiquement activées." },
                { "label39", "Écouter sur le port choisi" },
                { "label37", "Statut" },
                { "simpleButton13", "Construire" },
                { "simpleButton2", "Enregistrer tous les journaux sur le disque" },
                { "simpleButton3", "Vérificateur de journaux" },
                { "simpleButton4", "Rechercher *Metamask sur le disque" },
                { "simpleButton5", "Rechercher *Tous les portefeuilles sur le disque" },
                { "simpleButton6", "Effacer tous les journaux" },
                { "simpleButton7", "Supprimer tous les journaux" },
                { "simpleButton1", "Démarrer le serveur ZeroTrace sur le port choisi" },
                { "simpleButton12", "Rechercher *Portefeuille Metamask" },
                { "simpleButton11", "Rechercher *Portefeuille Exodus" },
                { "simpleButton10", "Effacer la liste des mots de passe" },
                { "simpleButton9", "Rechercher *Site web spécifique" },
                { "simpleButton8", "Rechercher *Mots de passe sur le disque" },
                { "accordionControlElement1", "Tableau de bord" },
                { "accordionControlElement2", "Journaux" },
                { "accordionControlElement3", "Paramètres du Stealer" },
                { "accordionControlElement4", "À propos" },
                { "accordionControlElement5", "Constructeur" },
                { "accordionControlElement6", "Construire ZeroTrace" },
                { "accordionControlElement7", "À propos" },
                { "accordionControlElement8", "Quitter le logiciel" },
                { "accordionControlElement9", "Quitter" },
                { "label86", "À propos de ZeroTrace Stealer" },
                { "label86_longText", "ZeroTrace Stealer est un outil avancé de collecte de données créé par l'équipe ZeroTrace, conçu pour aider à la collecte complète de données. Développé avec des technologies de pointe, il permet aux utilisateurs de collecter et de gérer efficacement des informations sensibles.\nFonctionnalités principales :\nExtraction de mots de passe : Collecte les mots de passe stockés des navigateurs, applications, etc.\nCookies et journaux de session : Recueille les cookies et les détails de session pour un accès rapide.\nCollecte de fichiers : Cible des types de fichiers spécifiques dans des répertoires prédéfinis.\nDonnées Discord/Telegram : Capture les jetons et les informations d'identification pour les plateformes de communication.\nCaptures d'écran et détails du système : Capture automatiquement des captures d'écran du bureau et extrait des informations système.\nDonnées de jeu et configurations VPN : Récupère les profils de jeu et les détails VPN.\nIntégration du panneau : Envoie les données collectées en toute sécurité à votre panneau personnalisé pour analyse.\nEt bien plus encore.\nConçu pour un usage professionnel\nZeroTrace Stealer est conçu pour les professionnels des tests de pénétration et du piratage éthique.\nL'outil démontre l'importance de sécuriser les informations sensibles et sert de rappel pour améliorer les mesures de cybersécurité.\nAvertissement : ZeroTrace Stealer est destiné uniquement à des fins éducatives.\nLes développeurs interdisent strictement son utilisation pour des activités illégales ou contraires à l'éthique." },
                { "label90", "Le logiciel original ne peut être trouvé que sur notre page Github." },
                { "label75", "Ce logiciel est entièrement gratuit. Si vous l'avez acheté, vous avez commis une erreur." }
            };

            // Chinese translations
            translations["Chinese"] = new Dictionary<string, string>
            {
                { "label1", "总日志" },
                { "label3", "在此期间" },
                { "label6", "上周" },
                { "label4", "整周期间" },
                { "label9", "最近30天" },
                { "label7", "整月期间" },
                { "label12", "密码总数" },
                { "label10", "所有时间内" },
                { "label85", "构建器" },
                { "label88", "所有功能自动开启。" },
                { "label39", "监听所选端口" },
                { "label37", "状态" },
                { "simpleButton13", "构建" },
                { "simpleButton2", "将所有日志保存到磁盘" },
                { "simpleButton3", "日志检查器" },
                { "simpleButton4", "查找磁盘上的*Metamask" },
                { "simpleButton5", "查找磁盘上的*所有钱包" },
                { "simpleButton6", "清除所有日志" },
                { "simpleButton7", "删除所有日志" },
                { "simpleButton1", "在所选端口上启动ZeroTrace服务器" },
                { "simpleButton12", "查找*Metamask钱包" },
                { "simpleButton11", "查找*Exodus钱包" },
                { "simpleButton10", "清除所有密码列表" },
                { "simpleButton9", "查找*特定网站" },
                { "simpleButton8", "查找磁盘上的*密码" },
                { "accordionControlElement1", "仪表板" },
                { "accordionControlElement2", "日志" },
                { "accordionControlElement3", "Stealer设置" },
                { "accordionControlElement4", "关于" },
                { "accordionControlElement5", "构建器" },
                { "accordionControlElement6", "构建ZeroTrace" },
                { "accordionControlElement7", "关于" },
                { "accordionControlElement8", "退出软件" },
                { "accordionControlElement9", "退出" },
                { "label86", "关于ZeroTrace Stealer" },
                { "label86_longText", "ZeroTrace Stealer是由ZeroTrace团队创建的高级数据收集工具，旨在协助全面收集数据。使用尖端技术开发，它为用户提供了高效收集和管理敏感信息的能力。\n主要功能：\n密码提取：从浏览器、应用程序等收集存储的密码。\nCookie和会话日志：收集Cookie和会话详细信息以便快速访问。\n文件收集：从预定义目录中获取特定文件类型。\nDiscord/Telegram数据：捕获通信平台的令牌和凭据。\n屏幕截图和系统详细信息：自动捕获桌面截图并提取系统信息。\n游戏数据和VPN配置：检索游戏配置文件和VPN详细信息。\n面板集成：安全地将收集的数据发送到您的自定义面板进行分析。\n以及更多功能。\n为专业用途设计\nZeroTrace Stealer专为渗透测试和道德黑客专业人员量身定制。\n该工具展示了保护敏感信息的重要性，并提醒加强网络安全措施。\n免责声明：ZeroTrace Stealer仅用于教育目的。\n开发人员严禁将其用于非法或不道德活动。" },
                { "label90", "原始软件只能在我们的Github页面上找到。" },
                { "label75", "此软件完全免费。如果您购买了它，您犯了一个错误。" }
            };

            // German translations
            translations["Deutsche"] = new Dictionary<string, string>
            {
                { "label1", "Gesamtprotokoll" },
                { "label3", "Während dieser ganzen Zeit" },
                { "label6", "Letzte Woche" },
                { "label4", "Während der ganzen Woche" },
                { "label9", "Letzte 30 Tage" },
                { "label7", "Während des ganzen Monats" },
                { "label12", "Gesamtpasswörter" },
                { "label10", "Während der gesamten Zeit" },
                { "label85", "Builder" },
                { "label88", "Alle Funktionen sind automatisch aktiviert." },
                { "label39", "Auf gewähltem Port hören" },
                { "label37", "Status" },
                { "simpleButton13", "Erstellen" },
                { "simpleButton2", "Alle Logs auf Festplatte speichern" },
                { "simpleButton3", "Log-Prüfer" },
                { "simpleButton4", "Suche *Metamask auf Festplatte" },
                { "simpleButton5", "Suche *Alle Wallets auf Festplatte" },
                { "simpleButton6", "Alle Logs löschen" },
                { "simpleButton7", "Alle Logs löschen" },
                { "simpleButton1", "ZeroTrace-Server auf gewähltem Port starten" },
                { "simpleButton12", "Suche *Metamask Wallet" },
                { "simpleButton11", "Suche *Exodus Wallet" },
                { "simpleButton10", "Passwortliste löschen" },
                { "simpleButton9", "Suche *Spezifische Website" },
                { "simpleButton8", "Suche *Passwörter auf Festplatte" },
                { "accordionControlElement1", "Dashboard" },
                { "accordionControlElement2", "Logs" },
                { "accordionControlElement3", "Stealer-Einstellungen" },
                { "accordionControlElement4", "Über" },
                { "accordionControlElement5", "Builder" },
                { "accordionControlElement6", "ZeroTrace erstellen" },
                { "accordionControlElement7", "Über" },
                { "accordionControlElement8", "Software beenden" },
                { "accordionControlElement9", "Beenden" },
                { "label86", "Über ZeroTrace Stealer" },
                { "label86_longText", "ZeroTrace Stealer ist ein fortschrittliches Datensammlungstool, das vom ZeroTrace-Team entwickelt wurde und für die umfassende Datenerfassung konzipiert ist. Mit modernsten Technologien entwickelt, bietet es Benutzern die Möglichkeit, sensible Informationen effizient zu sammeln und zu verwalten.\nHauptfunktionen:\nPasswortextraktion: Sammelt gespeicherte Passwörter aus Browsern, Apps und mehr.\nCookies & Sitzungsprotokolle: Sammelt Cookies und Sitzungsdetails für schnellen Zugriff.\nDateisammlung: Zielt auf bestimmte Dateitypen aus vordefinierten Verzeichnissen ab.\nDiscord/Telegram-Daten: Erfasst Tokens und Anmeldeinformationen für Kommunikationsplattformen.\nScreenshots & Systemdetails: Nimmt automatisch Desktop-Screenshots auf und extrahiert Systeminformationen.\nSpiel-Daten & VPN-Konfigurationen: Ruft Spielprofile und VPN-Details ab.\nPanel-Integration: Sendet gesammelte Daten sicher an Ihr benutzerdefiniertes Panel zur Analyse.\nUnd vieles mehr.\nFür professionelle Nutzung konzipiert\nZeroTrace Stealer ist für Penetrationstests und ethisches Hacking konzipiert.\nDas Tool demonstriert die Wichtigkeit der Sicherung sensibler Informationen und dient als Erinnerung zur Verbesserung von Cybersicherheitsmaßnahmen.\nHaftungsausschluss: ZeroTrace Stealer ist nur für Bildungszwecke bestimmt.\nDie Entwickler verbieten strikt die Verwendung für illegale oder unethische Aktivitäten." },
                { "label90", "Die Originalsoftware ist nur auf unserer Github-Seite zu finden." },
                { "label75", "Diese Software ist völlig kostenlos. Wenn Sie sie gekauft haben, haben Sie einen Fehler gemacht." }
            };
        }

        // Get translation for a specific control and language
        public static string GetTranslation(string languageName, string controlName)
        {
            // If language is English or language not found, return original text (no translation needed)
            if (languageName == "English" || !translations.ContainsKey(languageName))
                return null;

            // Get dictionary for selected language
            var languageDict = translations[languageName];

            // Return translation if exists, otherwise return null (will keep original text)
            if (languageDict.ContainsKey(controlName))
                return languageDict[controlName];

            return null;
        }
    }
}