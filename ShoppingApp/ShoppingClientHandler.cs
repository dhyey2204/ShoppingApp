using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ShoppingClientHandler
    {
        private readonly CancellationToken m_cancellationToken;
       
        private readonly ShoppingCart m_cart;

        private readonly TcpClient m_tcpClient;

        public string ProductName { get; set; } = "";
        public int Accno { get; set; } = 1;
        
        private readonly ConcurrentDictionary<int, ShoppingCart> m_currentCart = new ConcurrentDictionary<int,ShoppingCart>();
        //adding products


        public ShoppingClientHandler(TcpClient tcpClient, CancellationToken cancellationToken, ShoppingCart cartes)
        {
            Accno++;
            m_tcpClient = tcpClient;
            m_cancellationToken = cancellationToken;
            m_cart = cartes;
            
            

        }

        public void Run() 
        {
            using (m_tcpClient) 
            {
                try
                {

                    
                    NetworkStream stream = m_tcpClient.GetStream();
                    StreamReader reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);
                    m_cancellationToken.Register(stream.Close);
                    while (!m_cancellationToken.IsCancellationRequested) 
                    {
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            if ("DISCONNECT" == line)
                            {
                                
                                Console.WriteLine("DISCONNECTED");
                                //m_currentCart.TryRemove(Accno, out _);
                                writer.Flush();
                                break;

                            }
                            else 
                            {
                                //ShoppingCart cart = m_currentCart.Values.Single(tb => tb.accountno == Accno);
                                if (line.StartsWith("CONNECT:") && m_currentCart.TryAdd(Accno, m_cart))
                                {
                                    string[] lineinfo = line.Split(':');
                                    if (2 == lineinfo.Length && int.TryParse(lineinfo[1], out int accountno))
                                    {
                                        Accno = accountno;
                                        string create = lineinfo[0];
                                        if ("CONNECT" == create)
                                        {
                                            //cart.accountno = accountno;

                                            (bool validation, string user) = m_cart.checkuser(accountno);

                                            if (validation == true)
                                            {
                                                //m_currentCart.TryAdd(Accno,m_cart);
                                                //m_currentCart.Values.Single(tb => tb.UserName == user);
                                                m_cart.UserName = user;
                                                writer.WriteLine($"CONNECTED:{user}");
                                                Console.WriteLine($"CONNECTED:{user}");
                                                writer.Flush();

                                            }
                                            else
                                            {
                                                writer.WriteLine("CONNECT_ERROR");
                                                Console.WriteLine("CONNECT_ERROR");
                                                writer.Flush();
                                            }
                                        }

                                    }
                                    else 
                                    {
                                        writer.WriteLine("CONNECT_ERROR");
                                        Console.WriteLine("CONNECT_ERROR");
                                        writer.Flush();

                                    }
                                }
                                else if ("GET_PRODUCTS" == line)
                                {
                                                                   
                                    string response = "PRODUCTS:";
                             
                                    foreach (var product in m_cart.Products)
                                    {                                                                             
                                        response += ($"{product.ProductName}," + $"{product.Quantity}")+ "|";
                                       
                                    }
                                    response = response.Substring(0, response.Length - 1);
                                    writer.WriteLine(response);
                                    Console.WriteLine(response);
                                    
                                    writer.Flush();
                                }
                                else if ("GET_ORDERS" == line)
                                {

                                    List<OrdersInServer> orders = m_cart.GetOrders();
                                    string response = "ORDERS:";
                                    if (orders != null)
                                    {
                                        foreach (var order in orders)
                                        {
                                            response += ($"{order.ProductName}," + $"{order.Quantity}," + $"{order.UserName}") + "|";

                                        }
                                        response = response.Substring(0, response.Length - 1);
                                        writer.WriteLine(response);
                                        Console.WriteLine(response);

                                        writer.Flush();
                                    }
                                    else 
                                    {
                                        writer.WriteLine("");
                                        writer.Flush();

                                    }
                                    
                                }
                                else if (line.StartsWith("PURCHASE:"))
                                {
                                    
                                    string[] lineinfo = line.Split(':');
                                    if (2 == lineinfo.Length) 
                                    {
                                        ProductName = lineinfo[1]; //getting name
                                        m_cart.ProductName = ProductName;

                                        string status = m_cart.purchase(ProductName);
                                        if ("DONE" ==status)
                                        {
                                            writer.WriteLine("DONE");
                                            writer.Flush();
                                        }
                                        else if ( "NOT_AVAILABLE" == status) 
                                        {
                                            writer.WriteLine("NOT_AVAILABLE");
                                            writer.Flush();
                                        }
                                        else if ("NOT_VALID" == status)
                                        {
                                            writer.WriteLine("NOT_VALID");
                                            writer.Flush();
                                        }

                                        Console.WriteLine(status);



                                    }



                                }


                            }

                            
                        }
                        else
                        {
                            Console.WriteLine("Client did not send command yet");
                            writer.Flush();
                        }
                    }

                }
                catch (IOException) // Exception takes us out of the loop, so client handler thread will end
                {
                    Console.WriteLine("***Network Error***");
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("***Network Error***"); // May occur if read  or write is attempted after stream is closed
                }
                catch (OutOfMemoryException)
                {
                    // Catch buffer overflow exception
                    // Connection will close upon leaving the using block
                }
                finally 
                {
                    //m_currentCart.TryRemove(Accno,out _);
                    //m_currentCart
                }
            }
            
        }
        
        
        

    }
}
