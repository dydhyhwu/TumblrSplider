using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DY.Crawler.Core.Domains.Extensions;
using TumblrSplider.Domains;
using TumblrSplider.Infrastructures.Services;
using TumblrSplider.Infrastructures.ServicesImpl;

namespace TumblrSplider
{
    public partial class Form1 : Form
    {
        public delegate void SetUserList(IEnumerable<string> users);

        public delegate void SetUserStatus(int grid_index, int cell_index, string status);

        private TumblrService tumblr_service;
        private FileService file_service;
        private PageService page_service;
        private BlockingCollection<UserQueue> user_queue;
        private BlockingCollection<UserQueue> user_info_queue;

        public Form1()
        {
            InitializeComponent();
            user_queue = new BlockingCollection<UserQueue>();
            user_info_queue = new BlockingCollection<UserQueue>();
            create_task();
            if (!Directory.Exists("./Data")) Directory.CreateDirectory("./Data");
            StartTime.Text = "开始时间：" + DateTime.Now;
        }

        private void init_services(string proxy)
        {
            page_service = new PageServiceImpl(get_client(proxy));
            tumblr_service = new TumblrServiceImpl(page_service);
            file_service = new FileServiceImpl(get_client(proxy));
        }

        private void create_task()
        {
            1.to(5).each(x =>
                         {
                             Task.Factory.StartNew(() => search_followers());
                         });

            1.to(5).each(x =>
                         {
                             Task.Factory.StartNew(() => search_resources());
                         });
        }

        private void search_resources()
        {
            while (true)
            {
                var item = user_info_queue.Take();
                set_grid_value(item.GridIndex, 5, "抓取内容中");
                var resource = tumblr_service.get_posts(item.UserName);
                set_grid_value(item.GridIndex, 3, resource.Photos.Count().ToString());
                set_grid_value(item.GridIndex, 4, resource.Videos.Count().ToString());
                set_grid_value(item.GridIndex, 5, "下载中");
                if (IsDownloadPhoto.Checked) file_service.DownloadByUrls(resource.Photos, item.UserName, "Photos");
                if (IsDownloadVideo.Checked) file_service.DownloadByUrls(resource.Videos, item.UserName, "Videos");
                set_grid_value(item.GridIndex, 5, "下载完成");
            }
        }

        private void set_grid_value(int grid_index, int cell_index, string status)
        {
            if (User_List.InvokeRequired)
            {
                var fc = new SetUserStatus(set_grid_value);
                this.Invoke(fc, grid_index, cell_index, status);
            }
            else
            {
                User_List.Rows[grid_index].Cells[cell_index].Value = status;
            }
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Cur_Url_Text.Text))
            {
                MessageBox.Show(this, "初始昵称不可为空");
                return;
            }
            if (string.IsNullOrEmpty(Proxy_Text.Text))
            {
                MessageBox.Show(this, "请填写代理IP");
                return;
            }
            enable_control();
            init_services(Proxy_Text.Text);

            user_queue.Add(new UserQueue()
                           {
                               GridIndex = -1,
                               UserName = Cur_Url_Text.Text,
                           });
        }

        private void enable_control()
        {
            Start_Button.Enabled = false;
            IsDownloadPhoto.Enabled = false;
            IsDownloadVideo.Enabled = false;
            Proxy_Text.Enabled = false;
        }

        private void search_followers()
        {
            while (true)
            {
                var item = user_queue.Take();
                if (item.GridIndex != -1)
                    set_grid_value(item.GridIndex, 5, "抓取粉丝中");
                var users = tumblr_service.get_followers(item.UserName);
                set_user_list(users);
                if (item.GridIndex != -1)
                {
                    set_grid_value(item.GridIndex, 2, users.Count().ToString());
                    set_grid_value(item.GridIndex, 5, "待抓取内容");
                }
            }
        }

        private void set_user_list(IEnumerable<string> users)
        {
            if (User_List.InvokeRequired)
            {
                var fc = new SetUserList(set_user_list);
                this.Invoke(fc, users);
            }
            else
            {
                foreach (var user in users)
                {
                    int cur_index = User_List.Rows.Add();
                    var row = User_List.Rows[cur_index];
                    row.Cells[0].Value = cur_index;
                    row.Cells[1].Value = user;
                    row.Cells[2].Value = "";
                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                    row.Cells[5].Value = "等待中";

                    // 入粉丝抓取队列
                    user_queue.Add(new UserQueue()
                                   {
                                       GridIndex = cur_index,
                                       UserName = user,
                                   });

                    // 入内容抓取队列
                    user_info_queue.Add(new UserQueue()
                                        {
                                            GridIndex = cur_index,
                                            UserName = user,
                                        });
                }
            }
        }

        private HttpClient get_client(string proxy)
        {
            var hanlder = new HttpClientHandler()
                          {
                              AutomaticDecompression = DecompressionMethods.GZip,
                              UseProxy = true,
                              Proxy = new WebProxy(proxy)
                          };
            HttpClient client = new HttpClient(hanlder);
            return client;
        }
    }
}
//http://127.0.0.1:1080