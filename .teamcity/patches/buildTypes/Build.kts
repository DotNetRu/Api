package patches.buildTypes

import jetbrains.buildServer.configs.kotlin.v2018_2.*
import jetbrains.buildServer.configs.kotlin.v2018_2.buildFeatures.PullRequests
import jetbrains.buildServer.configs.kotlin.v2018_2.buildFeatures.commitStatusPublisher
import jetbrains.buildServer.configs.kotlin.v2018_2.buildFeatures.pullRequests
import jetbrains.buildServer.configs.kotlin.v2018_2.ui.*

/*
This patch script was generated by TeamCity on settings change in UI.
To apply the patch, change the buildType with id = 'Build'
accordingly, and delete the patch script.
*/
changeBuildType(RelativeId("Build")) {
    vcs {

        check(checkoutMode == CheckoutMode.AUTO) {
            "Unexpected option value: checkoutMode = $checkoutMode"
        }
        checkoutMode = CheckoutMode.ON_AGENT

        check(cleanCheckout == false) {
            "Unexpected option value: cleanCheckout = $cleanCheckout"
        }
        cleanCheckout = true
    }

    features {
        add {
            pullRequests {
                provider = github {
                    authType = token {
                        token = "credentialsJSON:c97a1c72-0f46-4979-a3de-93abed177766"
                    }
                    filterAuthorRole = PullRequests.GitHubRoleFilter.MEMBER
                }
            }
        }
        add {
            commitStatusPublisher {
                publisher = github {
                    githubUrl = "https://api.github.com"
                    authType = personalToken {
                        token = "credentialsJSON:c97a1c72-0f46-4979-a3de-93abed177766"
                    }
                }
            }
        }
    }
}
