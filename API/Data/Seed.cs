using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.News.Any())
            {
                var news = new List<News>
                {
                    new News
                    {
                        Title = "WISeKey’s Subsidiary, SEALSQ’s Post-Quantum Chips Designed to Improve AI Performance in Semiconductors",
                        Body = "WISeKey International Holding Ltd. (“WISeKey”) (SIX: WIHN, NASDAQ: WKEY), a leader in cybersecurity, digital identity, and Internet of Things (IoT) solutions operating as a holding company, today announced that its Semiconductors & PKI subsidiary SEALSQ Corp. (NASDAQ: LAES) comprehensive post-quantum chips are designed to improve AI performance in semiconductors, bringing unprecedented capabilities to the technology world. SEALSQ’s wide range of solutions include secure elements, root of trust, cryptographic keys, and hardware security modules, underscore SEALSQ's commitment to spearheading technological advancements while fortifying semiconductors against potential vulnerabilities."
                    },
                    new News
                    {
                        Title = "99 Acquisition Group Inc. Announces Pricing of $75,000,000 Initial Public Offering",
                        Body = "99 Acquisition Group Inc. (the \"Company\") announced today that it priced its initial public offering of 7,500,000 units at $10.00 per unit. The units will be listed on Nasdaq Global Market (“Nasdaq”) and are expected to begin trading tomorrow, August 18, 2023, under the ticker symbol \"NNAGU\". Each unit consists of one share of Class A common stock, one redeemable warrant and one right. Each warrant entitles the holder thereof to purchase one ordinary share at a price of $11.50 per share. Each right entitles the holder thereof to receive one-fifth (1/5) of one share of Class A common stock upon the consummation of an initial business combination. Once the securities comprising the units begin separate trading, the shares of Class A common stock, warrants and rights are expected to be listed on Nasdaq under the symbols \"NNAG\", \"NNAGW\" and \"NNAGR\", respectively."
                    },
                    new News
                    {
                        Title = "Global Blockchain Acquisition Corp. and Cardea Corporate Holdings, Inc. Announce the Execution of a Definitive Merger Agreement",
                        Body = "Global Blockchain Acquisition Corp. (NASDAQ: GBBK) (“GBBK”), a publicly traded special purpose acquisition company, and Cardea Corporate Holdings, Inc. (\"Cardea\"), an emerging global wealth management firm, today announced they have entered into a definitive agreement for a business combination (the “Merger Agreement”). The transaction reflects an implied pro-forma enterprise valuation for Cardea of approximately $175 million. The transaction consideration will be paid in newly issued shares of common stock of GBBK. Upon completion of the transaction, GBBK will be renamed “Cardea Capital Holdings, Inc.” and will be listed on The Nasdaq Stock Market LLC (“Nasdaq”). The transaction is expected to provide Cardea with financing to fund its growth strategy globally. Cardea aims to create value through aggregation and integration, bringing new and innovative wealth management solutions to acquisitions as they are integrated."
                    },
                    new News
                    {
                        Title = "MediciNova Announces Abstract Regarding MN-166 (ibudilast) in Glioblastoma Accepted for Presentation at the Annual Meeting of the Society for Neuro-Oncology",
                        Body = "MediciNova, Inc., a biopharmaceutical company traded on the NASDAQ Global Market (NASDAQ:MNOV) and the Standard Market of the Tokyo Stock Exchange (Code Number: 4875), today announced that an abstract regarding tumor tissue analysis data from a clinical trial of MN-166 (ibudilast) in glioblastoma has been selected for poster presentation at the 28th Annual Meeting of the Society for Neuro-Oncology (SNO) to be held November 15 - 19, 2023 in Vancouver, British Columbia, Canada. The poster will be presented by MediciNova’s collaborator, Dr. Justin Lathia, Vice Chair in the Department of Cardiovascular and Metabolic Sciences and Co-Director of the Brain Tumor Research and Therapeutic Development Center of Excellence at the Lerner Research Institute at Cleveland Clinic; Professor, Department of Molecular Medicine at Case Western Reserve University School of Medicine; and Co-Leader, Molecular Oncology Program, Case Comprehensive Cancer Center."
                    },
                    new News
                    {
                        Title = "Singing Machine to Announce its Financial Results for the First Quarter Fiscal 2024",
                        Body = "The Singing Machine Company, Inc. (NASDAQ: MICS) is the worldwide leader in consumer karaoke products. Based in Fort Lauderdale, Florida, and founded over forty years ago, the Company designs and distributes the industry's widest assortment of at-home and in-car karaoke entertainment products. Their portfolio is marketed under both proprietary brands and popular licenses, including Carpool Karaoke and Sesame Street. Singing Machine products incorporate the latest technology and provide access to over 100,000 songs for streaming through its mobile app and select WiFi-capable products and is also developing the world’s first globally available, fully integrated in-car karaoke system."
                    },
                    new News
                    {
                        Title = "Anika Receives 510(k) Clearance for Integrity™ Implant System, a Regenerative Hyaluronic Acid-Based Patch System for Augmentation of Rotator Cuff Repairs",
                        Body = "Anika Therapeutics, Inc. (NASDAQ: ANIK), a global joint preservation company focused on early intervention orthopedics, today announced that it has received the final 510(k) clearance from the FDA for the Integrity Implant System. The system is designed to augment an injured tendon to promote healing in rotator cuff repair procedures. Clearance of the hyaluronic acid (HA) based patch component joins the prior 510(k)s received for the associated fixation devices and instrumentation. The Integrity implant is a flexible, knitted, HA-based scaffold that provides improved strength and regenerative capacity over first generation collagen patches, and supports regenerative healing through improved cell infiltration, tissue remodeling1, and tendon thickening."
                    },
                    new News
                    {
                        Title = "LifeWallet files its Form 10-Q for the period ended March 31, 2023",
                        Body = "MSP Recovery, Inc. d/b/a LifeWallet (NASDAQ: LIFW) (\"LifeWallet,\" or the \"Company\"), a Medicare, Medicaid, commercial, and secondary payer reimbursement recovery and technology leader, announced it has filed its Form 10-Q for the period ended March 31, 2023. Additionally, the Company received a notification letter on August 16, 2023 from the Listing Qualifications Department of the Nasdaq Stock Market LLC (“Nasdaq”) stating the Company was not in compliance with the requirements of Nasdaq Listing Rule 5250(c)(1) as a result of not having timely filed its Form 10-Q for the period ended June 30, 2023 (the “Form 10-Q”) with the Securities and Exchange Commission (“SEC”)."
                    },
                    new News
                    {
                        Title = "Sun Communities, Inc. Declares Third Quarter 2023 Distribution",
                        Body = "Sun Communities, Inc. (NYSE: SUI) (the \"Company\"), a real estate investment trust (“REIT”) that owns and operates, or has an interest in, manufactured housing (“MH”) and recreational vehicle (“RV”) communities and marinas (collectively, the \"properties\"), today announced its Board of Directors declared a quarterly distribution of $0.93 per share of common stock for the third quarter of 2023. The distribution is payable on October 16, 2023 to shareholders of record on September 29, 2023."
                    },
                    new News
                    {
                        Title = "Horizon Aircraft, an electric Vertical TakeOff and Landing (eVTOL) aircraft developer, announces the signing of a definitive agreement to go public via a business combination with Pono Capital Three, Inc., a Nasdaq listed company. - Updated",
                        Body = "Pono Capital Three, Inc. (NASDAQ: PTHR, PTHRU and PTHRW), a special purpose acquisition company (“Pono”), has announced the execution of a definitive Business Combination Agreement (the “Business Combination Agreement”) with Robinson Aircraft Ltd. (the “Target Company”), a British Columbia company doing business as Horizon Aircraft (“Horizon Aircraft”). Pursuant to the Business Combination Agreement, it is intended that the Target Company will amalgamate with Pono Three Merger Sub, Inc., a wholly owned subsidiary of Pono, with the resulting combined company continuing as a wholly owned subsidiary of Pono. Stockholders of the Target Company will receive shares of common stock of Pono (the “Business Combination”). In connection with the Business Combination, it is expected that the Target Company will change its name to “Horizon Aircraft, Inc.,” and that Pono will redomesticate as a British Columbia company (the “Redomestication”) and change its name to “Horizon Aircraft Holdings Incorporated.”"
                    },
                    new News
                    {
                        Title = "Nxu Announces Strategic Focus on EV Charging Infrastructure",
                        Body = "Nxu Inc., (NASDAQ: NXU) (“Nxu”, “the Company”), a domestic technology company creating energy storage and charging solutions for the infrastructure we need to power our electrified future, announced today a strategic shift to focus on its EV charging infrastructure technology. Nxu’s differentiated charging and energy storage technology has the potential to expedite the vision for our collective electrified future, so the immediate focus of the Company is aimed at concentrating and leveraging the resources and efforts that advance the realization of that vision. This re-sequencing of our product roadmap to prioritize our charging technology puts the Company on the path to near-term revenue generation with a unique and highly competitive solution to address the worldwide EV charging station shortage. With the ultimate goal of creating shareholder value and achieving profitability, the Company intends to leverage the favorable economics on its initial deployment to rapidly scale."
                    }                   
                };

                await context.News.AddRangeAsync(news);
                await context.SaveChangesAsync();
            }
        }
    }
}