using System;
using System.Collections.Generic;
using System.Net.Http;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Core.Domains
{
    public class Account : Aggregate, Nameable
    {
        public Account()
        {
            data_dic = new List<AccountData>();
        }
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        protected IList<AccountData> data_dic { get; set; }

        public virtual IEnumerable<AccountData> DataDic
        {
            get { return data_dic; }
        }

        public virtual void add_data(AccountData data)
        {
            data_dic.Add(data);
        }

        public virtual string login(string url, HttpClient client)
        {
            url.get_content(client);
            var post_data = new FormUrlEncodedContent(DataDic.get_params());
            return client.PostAsync(url, post_data).Result.Content.ReadAsStringAsync().Result;
        }
    }
}