Feature: Google Cloud Pricing Calculator

Scenario: Calculate monthly rent for Compute Engine
	Given I navigate to "https://cloud.google.com/"
	When I click the search button at the top of the portal page
	And I enter "Google Cloud Platform Pricing Calculator" into the search field
	And I click "Google Cloud Platform Pricing Calculator" in the search results
	And I click COMPUTE ENGINE at the top of the page
	And I fill out the form with the following data:
		| Field                       | Value                                                                 |
		| Number of instances         | 4                                                                     |
		| Operating System / Software | Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License) |
		| VM Class                    | Regular                                                               |
		| Instance type               | n1-standard-8vCPUs: 8, RAM: 30GiB                                     |
		| Number of GPUs              | 1                                                                     |
		| GPU type                    | NVIDIA TESLA P100                                                     |
		| Local SSD                   | 2x375 GB                                                              |
		| Datacenter location         | Belgium (europe-west1)                                                |
		| Committed usage             | 1 year                                                                |
	And I click more options
	Then the estimated data should be correct:
		| Field           | Expected Value                      |
		| VM Class        | Regular                             |
		| Instance type   | n1-standard-8, vCPUs: 8, RAM: 30 GB |
		| Region          | Belgium (europe-west1)              |
		| Local SSD       | 2x375 GB                            |
		| Commitment term | 1 year                              |
	And the monthly rent should match the manual calculation result

    
 
